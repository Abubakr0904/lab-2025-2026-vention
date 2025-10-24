import re

with open('best-practices.html', 'r', encoding='utf-8') as f:
    content = f.read()

# Check div balance around slides 33-40
lines = content.split('\n')
div_count = 0
for i in range(970, 1150):
    line = lines[i]
    
    # Count opening divs
    opening = len(re.findall(r'<div\s', line))
    # Count closing divs
    closing = len(re.findall(r'</div>', line))
    
    div_count += (opening - closing)
    
    if 'Slide 33' in line or 'Slide 34' in line or 'Slide 35' in line or 'Slide 36' in line or 'Slide 37' in line:
        print(f"\n=== Line {i+1}: {line[:80]}")
        print(f"Div balance at this line: {div_count}")
    
    if opening > 0 or closing > 0:
        if i > 1000 and i < 1110:
            print(f"Line {i+1}: opens={opening}, closes={closing}, balance={div_count} | {line[:80]}")

