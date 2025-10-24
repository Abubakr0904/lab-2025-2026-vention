import re

with open('best-practices.html', 'r', encoding='utf-8') as f:
    content = f.read()

# Count actual slide divs
slide_divs = re.findall(r'<div class="slide[^"]*"', content)
print(f"Total slide divs: {len(slide_divs)}")

# Find where slides end
lines = content.split('\n')
for i, line in enumerate(lines):
    if 'Slide 33' in line or 'Slide 34' in line or 'Slide 35' in line or 'Slide 36' in line:
        print(f"Line {i+1}: {line[:100]}")

