# School Tasks API

מערכת לניהול מטלות ופרויקטים של תלמידים או סטודנטים. המערכת מאפשרת למורים ליצור מטלות ולעקוב אחרי ההגשות, ולתלמידים להציג את המטלות שלהם.

---

## ישויות

### Student
- Id (int)
- Name (string)
- Email (string)
- Status (string) – סטטוס הגשה/פעילות

### Teacher
- Id (int)
- Name (string)
- Email (string)
- Status (string)

### Assignment
- Id (int)
- Title (string)
- Description (string)
- TeacherId (int)
- Status (string) – לא הוגש / הוגש / מוקצה ציון
- Grade (int?) – אופציונלי

---

## Endpoints

### Students

| פעולה                       | Method | Route                     | דוגמה JSON |
|-------------------------------|--------|---------------------------|-------------|
| שליפת רשימה                  | GET    | /api/students             | - |
| שליפת סטודנט לפי מזהה        | GET    | /api/students/{id}        | - |
| הוספת סטודנט                 | POST   | /api/students             | `{ "Name": "יוסי", "Email": "yossi@mail.com", "Status": "Active" }` |
| עדכון סטודנט                 | PUT    | /api/students/{id}        | `{ "Name": "יוסי כהן", "Email": "yossi@mail.com", "Status": "Inactive" }` |
| מחיקת סטודנט                 | DELETE | /api/students/{id}        | - |
| עדכון סטטוס                  | PUT    | /api/students/{id}/status | `"Active"` |

### Teachers

| פעולה                       | Method | Route                     | דוגמה JSON |
|-------------------------------|--------|---------------------------|-------------|
| שליפת רשימה                  | GET    | /api/teachers             | - |
| שליפת מורה לפי מזהה          | GET    | /api/teachers/{id}        | - |
| הוספת מורה                   | POST   | /api/teachers             | `{ "Name": "מר אבי", "Email": "avi@mail.com", "Status": "Active" }` |
| עדכון מורה                   | PUT    | /api/teachers/{id}        | `{ "Name": "מר אבי כהן", "Email": "avi@mail.com", "Status": "Inactive" }` |
| מחיקת מורה                   | DELETE | /api/teachers/{id}        | - |
| עדכון סטטוס                  | PUT    | /api/teachers/{id}/status | `"Inactive"` |

### Assignments

| פעולה                       | Method | Route                     | דוגמה JSON |
|-------------------------------|--------|---------------------------|-------------|
| שליפת רשימה                  | GET    | /api/assignments          | - |
| שליפת מטלה לפי מזהה           | GET    | /api/assignments/{id}     | - |
| הוספת מטלה                   | POST   | /api/assignments          | `{ "Title": "פרויקט מתמטיקה", "Description": "תרגול על מטריצות", "TeacherId": 1, "Status": "Not Submitted" }` |
| עדכון מטלה                   | PUT    | /api/assignments/{id}     | `{ "Title": "פרויקט מתמטיקה", "Description": "תרגול על מטריצות", "TeacherId": 1, "Status": "Submitted", "Grade": 95 }` |
| מחיקת מטלה                   | DELETE | /api/assignments/{id}     | - |
| עדכון סטטוס וציון             | PUT    | /api/assignments/{id}/status | `{ "Status": "Submitted", "Grade": 90 }` |

---

> הערה: כל השליפות של רשימות יכולות לקבל פרמטרים לסינון ומיון, לדוגמה: שליפת מטלות לפי סטטוס או תאריך הגשה.
