#!/usr/bin/env python3
# -*- coding: utf-8 -*-
import re

# Read the HTML file
with open('best-practices.html', 'r', encoding='utf-8') as f:
    content = f.read()

# Find all slide numbers
matches = re.findall(r'<!-- Slide (\d+)', content)
slide_numbers = sorted([int(m) for m in matches])

print(f"Total slides found: {len(slide_numbers)}")
print(f"Slide numbers: {slide_numbers[:10]}... {slide_numbers[-10:]}")

# Find missing numbers
all_numbers = set(range(1, 101))
found_numbers = set(slide_numbers)
missing = sorted(all_numbers - found_numbers)

if missing:
    print(f"\n❌ Missing slides: {missing}")
else:
    print("\n✅ All slides 1-100 are present!")

# Check for duplicates
duplicates = [num for num in slide_numbers if slide_numbers.count(num) > 1]
if duplicates:
    print(f"\n⚠️  Duplicate slides: {set(duplicates)}")


