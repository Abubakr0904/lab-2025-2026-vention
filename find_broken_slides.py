#!/usr/bin/env python3
# -*- coding: utf-8 -*-
import re

# Read the HTML file
with open('best-practices.html', 'r', encoding='utf-8') as f:
    content = f.read()

# Find all slide comments and check if they're followed by <div class="slide">
pattern = r'<!-- Slide (\d+)[^>]*-->\s*(<div class="slide[^"]*">)?'
matches = re.findall(pattern, content)

broken_slides = []
for slide_num, div_tag in matches:
    if not div_tag:
        broken_slides.append(int(slide_num))

if broken_slides:
    print(f"❌ Slides with comments but no <div> tag: {broken_slides}")
else:
    print("✅ All slides have proper <div> tags")

# Also check total div count
div_count = len(re.findall(r'<div class="slide', content))
print(f"\nTotal <div class=\"slide\"> found: {div_count}")
print(f"Expected: 100")

