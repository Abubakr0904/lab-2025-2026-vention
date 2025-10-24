import re

with open('best-practices.html', 'r', encoding='utf-8') as f:
    content = f.read()

# Find all slide divs and their classes
slides = re.findall(r'<!-- Slide (\d+)[:\s][^>]*>.*?<div class="([^"]+)"', content, re.DOTALL)

print(f"Total slides found: {len(slides)}\n")
print("First 40 slides:")
for num, cls in slides[:40]:
    print(f"Slide {num}: class=\"{cls}\"")

# Check for any slides without proper class
problematic = [(num, cls) for num, cls in slides if 'slide' not in cls]
if problematic:
    print(f"\n⚠️ Problematic slides:")
    for num, cls in problematic:
        print(f"Slide {num}: class=\"{cls}\"")

