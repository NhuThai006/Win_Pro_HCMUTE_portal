import re

with open('InsertDummyData.sql', 'r', encoding='utf-8') as f:
    content = f.read()

# Replace student weak passwords N'1' with N'Student123@'
content = content.replace(", N'1', N'", ", N'Student123@', N'")

# Replace admin weak passwords 123456 with Admin123@
content = content.replace(", N'123456', N'", ", N'Admin123@', N'")

with open('InsertDummyData.sql', 'w', encoding='utf-8') as f:
    f.write(content)
