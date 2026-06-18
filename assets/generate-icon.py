"""Kinetic bee (KIN4) — the locked BeeneticToolkit brand mark.

A "kinetic angle" bee inside a navy/amber hex with three flat motion streaks
carved to the bee's contour. Deltas from the earlier KIN3:
  - streaks have their OWN flat angle (decoupled from the bee), riding higher and
    more parallel to the ground;
  - streaks are skinnier and sharper (smaller radius, crisper taper);
  - the bee is rotated more upright (reads as travelling more vertically) and
    dropped slightly to sit centered in the hex.

Writes the three shipped files in one shot:
  - ../icon.png            (128px) — the NuGet PackageIcon
  - ./icon-512.png         (512px) — hi-res source / README/social
  - ./logo-200.png         (200px) — README header mark
"""
import math
import os
from PIL import Image, ImageDraw, ImageFilter, ImageChops

OUT = os.path.dirname(os.path.abspath(__file__))   # assets/
ROOT = os.path.dirname(OUT)                          # repo root
SS = 4
SIZE = 128
S = SIZE * SS

NAVY = (36, 42, 58, 255)
AMBER = (245, 183, 0, 255)
AMBER_LT = (255, 205, 60, 255)
INK = (20, 22, 30, 255)
WING = (228, 240, 255, 175)

# --- locked KIN4 (= "B drop2") parameters ---
BEE_TILT = -30             # more upright than KIN3's -44 (head up-right, steeper climb)
STREAK_THETA = 18          # degrees below horizontal: flatter, faster streaks
STREAK_R0 = 1.6            # skinnier than KIN3's 2.2
STREAK_ANCHOR_DY = -0.04   # nudge streaks up a touch
BEE_SCALE = 0.42 * S
BCX = 0.52 * S
BCY = 0.565 * S            # dropped to center the bee in the hex


def canvas():
    return Image.new("RGBA", (S, S), (0, 0, 0, 0))


def hexagon(cx, cy, r, rot=90):
    return [(cx + r * math.cos(math.radians(60 * i + rot)),
             cy + r * math.sin(math.radians(60 * i + rot))) for i in range(6)]


def paste_centered(base, layer, ax, ay):
    base.alpha_composite(layer, (int(ax - layer.width / 2), int(ay - layer.height / 2)))


def wing(scale, angle, factor=1.0, alpha=175):
    wlen, wwid = scale * 0.66 * factor, scale * 0.42 * factor
    box = int(max(wlen, wwid) * 1.7)
    w = Image.new("RGBA", (box, box), (0, 0, 0, 0))
    ImageDraw.Draw(w).ellipse([(box - wlen) / 2, (box - wwid) / 2,
                               (box + wlen) / 2, (box + wwid) / 2],
                              fill=(WING[0], WING[1], WING[2], alpha))
    return w.rotate(angle, expand=True, resample=Image.BICUBIC)


def add_rim(img, color=AMBER, px=8):
    alpha = img.getchannel("A")
    dil = alpha.filter(ImageFilter.MaxFilter(px | 1))
    out = canvas()
    out.paste(Image.new("RGBA", (S, S), color), (0, 0), dil)
    out.alpha_composite(img)
    return out


def bee(scale, body_w=0.38, wing_factor=1.18, rim_px=8):
    img = canvas()
    cx = cy = S / 2
    bw, bh = scale * body_w, scale * 0.60
    wax = scale * (0.26 + body_w * 0.30)
    paste_centered(img, wing(scale, 40, wing_factor), cx - wax, cy - scale * 0.20)
    paste_centered(img, wing(scale, -40, wing_factor), cx + wax, cy - scale * 0.20)
    d = ImageDraw.Draw(img)
    for sx in (-1, 1):
        tip = (cx + sx * scale * 0.30, cy - bh - scale * 0.30)
        d.line([(cx + sx * scale * 0.10, cy - bh * 0.95), tip], fill=INK, width=int(SS * 2.5))
        d.ellipse([tip[0] - SS * 3.5, tip[1] - SS * 3.5, tip[0] + SS * 3.5, tip[1] + SS * 3.5], fill=INK)
    d.ellipse([cx - bw, cy - bh, cx + bw, cy + bh], fill=AMBER, outline=INK, width=int(SS * 3))
    hr = bw * 0.70
    d.ellipse([cx - hr, cy - bh - hr * 0.85, cx + hr, cy - bh + hr * 1.15], fill=INK)
    stripes = canvas()
    sd = ImageDraw.Draw(stripes)
    for k in (-1, 0, 1):
        yy = cy + k * bh * 0.46
        sd.rectangle([cx - bw, yy - bh * 0.15, cx + bw, yy + bh * 0.15], fill=INK)
    mask = canvas()
    ImageDraw.Draw(mask).ellipse([cx - bw, cy - bh, cx + bw, cy + bh], fill=(255,) * 4)
    img.alpha_composite(Image.composite(stripes, canvas(), mask))
    return add_rim(img, px=rim_px)


def comet_streaks(center, scale):
    """Skinny, sharp comet streaks with their own flat angle (STREAK_THETA below
    horizontal). Drawn fully into the bee region; the near ends get carved later
    to the bee's exact (gap-offset) contour. Tapers + fades toward the tail."""
    layer = canvas()
    d = ImageDraw.Draw(layer)
    th = math.radians(STREAK_THETA)
    tx, ty = -math.cos(th), math.sin(th)      # trail toward lower-left, flatter as theta -> 0
    perpx, perpy = -ty, tx
    cx, cy = center
    cy += STREAK_ANCHOR_DY * scale
    bw = scale * 0.38
    offsets = [-0.5 * bw, 0.0, 0.5 * bw]              # 3 streaks
    hold = scale * 0.55                               # full width through (to-be-cut) bee region
    length = scale * 1.95                             # taper/fade region beyond
    r0 = SS * STREAK_R0
    a0 = 245
    steps = 170
    for off in offsets:
        ox, oy = cx + perpx * off, cy + perpy * off
        for i in range(steps):
            s = (hold + length) * (i / steps)
            t = 0.0 if s <= hold else (s - hold) / length
            r = max(0.5, r0 * (1 - t) ** 1.25)                  # sharper taper toward tail
            a = a0 if s <= hold else int(a0 * (1 - t) ** 1.5)   # fade toward tail
            if a <= 0:
                break
            x, y = ox + tx * s, oy + ty * s
            d.ellipse([x - r, y - r, x + r, y + r],
                      fill=(AMBER_LT[0], AMBER_LT[1], AMBER_LT[2], a))
    return layer


def render():
    base = canvas()
    d = ImageDraw.Draw(base)
    border_w = int(SS * 4)
    hexpts = hexagon(S / 2, S / 2, S * 0.50, rot=90)
    d.polygon(hexpts, fill=NAVY)
    d.polygon(hexpts, outline=AMBER, width=border_w)

    bee_layer = canvas()
    b = bee(BEE_SCALE).rotate(BEE_TILT, expand=False, resample=Image.BICUBIC)
    bee_layer.alpha_composite(b, (int(BCX - S / 2), int(BCY - S / 2)))

    # gap-dilated silhouette (downscaled for speed) -> crisp keep-out mask
    alpha_img = bee_layer.getchannel("A")
    ds = 4
    gap_px = BEE_SCALE * 0.07
    gsmall = max(1, int(gap_px / ds))
    small = alpha_img.resize((S // ds, S // ds), Image.BILINEAR)
    dil_small = small.filter(ImageFilter.MaxFilter(2 * gsmall + 1))
    cut_mask = dil_small.resize((S, S), Image.BILINEAR).point(lambda v: 255 if v > 110 else 0)

    streaks = comet_streaks((BCX, BCY), BEE_SCALE)
    # carve the bee's exact (gap-offset) contour out of the streaks
    streaks.putalpha(ImageChops.subtract(streaks.getchannel("A"), cut_mask))
    # clip to the exact navy interior: fill the hex, then punch out the border ring
    innermask = Image.new("L", (S, S), 0)
    im = ImageDraw.Draw(innermask)
    im.polygon(hexpts, fill=255)
    im.polygon(hexpts, outline=0, width=border_w + SS)
    streaks = Image.composite(streaks, canvas(), innermask)
    base.alpha_composite(streaks)
    base.alpha_composite(bee_layer)
    return base


def main():
    base = render()
    base.resize((512, 512), Image.LANCZOS).save(os.path.join(OUT, "icon-512.png"))
    base.resize((200, 200), Image.LANCZOS).save(os.path.join(OUT, "logo-200.png"))
    base.resize((SIZE, SIZE), Image.LANCZOS).save(os.path.join(ROOT, "icon.png"))
    print("wrote icon.png (128), assets/icon-512.png (512), assets/logo-200.png (200)")


if __name__ == "__main__":
    main()
