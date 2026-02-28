# API Documentation - LearnManager API

Based on your database schema and models, here's a comprehensive API specification:

## 1. Authentication Endpoints

### Register User
```
POST /api/auth/register
```
**Request Body:**
```json
{
  "name": "John Doe",
  "email": "john@example.com",
  "password": "SecurePassword123",
  "role": "student"
}
```
**Response (201 Created):**
```json
{
  "id": 1,
  "name": "John Doe",
  "email": "john@example.com",
  "role": "student",
  "createdAt": "2026-02-28T10:30:00Z"
}
```
**Status Codes:** 201 Created, 400 Bad Request (validation), 409 Conflict (email exists)

---

### Login User
```
POST /api/auth/login
```
**Request Body:**
```json
{
  "email": "john@example.com",
  "password": "SecurePassword123"
}
```
**Response (200 OK):**
```json
{
  "token": "eyJhbGciOiJIUzI1NiIs...",
  "user": {
    "id": 1,
    "name": "John Doe",
    "email": "john@example.com",
    "role": "student"
  }
}
```
**Status Codes:** 200 OK, 401 Unauthorized, 404 Not Found

---

## 2. Course Endpoints

### Get All Courses
```
GET /api/courses
```
**Query Parameters:**
- `page` (integer, optional): Page number (default: 1)
- `pageSize` (integer, optional): Items per page (default: 10)
- `search` (string, optional): Search by title or description

**Response (200 OK):**
```json
{
  "data": [
    {
      "id": 1,
      "title": "C# Basics",
      "description": "Learn C# fundamentals",
      "instructorId": 2,
      "instructor": {
        "id": 2,
        "name": "Jane Smith",
        "email": "jane@example.com"
      },
      "createdAt": "2026-02-01T08:00:00Z"
    }
  ],
  "totalCount": 5,
  "pageNumber": 1,
  "pageSize": 10
}
```

---

### Get Course by ID
```
GET /api/courses/{courseId}
```
**Path Parameters:**
- `courseId` (long, required): Course ID

**Response (200 OK):**
```json
{
  "id": 1,
  "title": "C# Basics",
  "description": "Learn C# fundamentals",
  "instructorId": 2,
  "instructor": {
    "id": 2,
    "name": "Jane Smith"
  },
  "lessons": [
    {
      "id": 1,
      "title": "Variables and Data Types",
      "orderIndex": 1
    }
  ],
  "quizzes": [
    {
      "id": 1,
      "title": "Module 1 Quiz"
    }
  ],
  "createdAt": "2026-02-01T08:00:00Z"
}
```
**Status Codes:** 200 OK, 404 Not Found

---

### Create Course
```
POST /api/courses
```
**Headers:**
- `Authorization: Bearer {token}` (required, instructor/admin only)

**Request Body:**
```json
{
  "title": "Advanced C#",
  "description": "Advanced topics in C#",
  "instructorId": 2
}
```
**Response (201 Created):**
```json
{
  "id": 2,
  "title": "Advanced C#",
  "description": "Advanced topics in C#",
  "instructorId": 2,
  "createdAt": "2026-02-28T10:30:00Z"
}
```
**Status Codes:** 201 Created, 400 Bad Request, 401 Unauthorized, 403 Forbidden

---

### Update Course
```
PUT /api/courses/{courseId}
```
**Headers:**
- `Authorization: Bearer {token}` (required, instructor/admin only)

**Path Parameters:**
- `courseId` (long, required)

**Request Body:**
```json
{
  "title": "Advanced C# Programming",
  "description": "Updated description",
  "instructorId": 2
}
```
**Response (200 OK):**
```json
{
  "id": 2,
  "title": "Advanced C# Programming",
  "description": "Updated description",
  "instructorId": 2,
  "createdAt": "2026-02-28T10:30:00Z"
}
```
**Status Codes:** 200 OK, 400 Bad Request, 401 Unauthorized, 403 Forbidden, 404 Not Found

---

### Delete Course
```
DELETE /api/courses/{courseId}
```
**Headers:**
- `Authorization: Bearer {token}` (required, instructor/admin only)

**Response (204 No Content)**

**Status Codes:** 204 No Content, 401 Unauthorized, 403 Forbidden, 404 Not Found

---

## 3. Lesson Endpoints

### Get All Lessons for a Course
```
GET /api/courses/{courseId}/lessons
```
**Path Parameters:**
- `courseId` (long, required)

**Query Parameters:**
- `page` (integer, optional): Page number
- `pageSize` (integer, optional): Items per page

**Response (200 OK):**
```json
{
  "data": [
    {
      "id": 1,
      "courseId": 1,
      "title": "Variables and Data Types",
      "content": "Lesson content here...",
      "orderIndex": 1
    }
  ],
  "totalCount": 10,
  "pageNumber": 1,
  "pageSize": 10
}
```

---

### Get Lesson by ID
```
GET /api/lessons/{lessonId}
```
**Path Parameters:**
- `lessonId` (long, required)

**Response (200 OK):**
```json
{
  "id": 1,
  "courseId": 1,
  "title": "Variables and Data Types",
  "content": "Lesson content here...",
  "orderIndex": 1
}
```

---

### Create Lesson
```
POST /api/courses/{courseId}/lessons
```
**Headers:**
- `Authorization: Bearer {token}` (required, instructor/admin only)

**Path Parameters:**
- `courseId` (long, required)

**Request Body:**
```json
{
  "title": "Control Flow",
  "content": "Learn about if statements, loops, etc.",
  "orderIndex": 2
}
```
**Response (201 Created):**
```json
{
  "id": 2,
  "courseId": 1,
  "title": "Control Flow",
  "content": "Learn about if statements, loops, etc.",
  "orderIndex": 2
}
```

---

### Update Lesson
```
PUT /api/lessons/{lessonId}
```
**Headers:**
- `Authorization: Bearer {token}` (required, instructor/admin only)

**Request Body:**
```json
{
  "title": "Control Flow (Updated)",
  "content": "Updated content...",
  "orderIndex": 2
}
```
**Response (200 OK)**

---

### Delete Lesson
```
DELETE /api/lessons/{lessonId}
```
**Headers:**
- `Authorization: Bearer {token}` (required, instructor/admin only)

**Response (204 No Content)**

---

## 4. Quiz Endpoints

### Get All Quizzes for a Course
```
GET /api/courses/{courseId}/quizzes
```
**Response (200 OK):**
```json
{
  "data": [
    {
      "id": 1,
      "courseId": 1,
      "title": "Module 1 Quiz",
      "questions": [
        {
          "id": 1,
          "questionText": "What is a variable?",
          "correctAnswer": "A named storage location"
        }
      ]
    }
  ]
}
```

---

### Get Quiz by ID
```
GET /api/quizzes/{quizId}
```
**Response (200 OK):**
```json
{
  "id": 1,
  "courseId": 1,
  "title": "Module 1 Quiz",
  "questions": [
    {
      "id": 1,
      "quizId": 1,
      "questionText": "What is a variable?",
      "correctAnswer": "A named storage location"
    }
  ]
}
```

---

### Create Quiz
```
POST /api/courses/{courseId}/quizzes
```
**Headers:**
- `Authorization: Bearer {token}` (required, instructor/admin only)

**Request Body:**
```json
{
  "title": "Module 2 Quiz",
  "questions": [
    {
      "questionText": "What is inheritance?",
      "correctAnswer": "A mechanism to acquire properties from base class"
    }
  ]
}
```
**Response (201 Created)**

---

### Submit Quiz
```
POST /api/quizzes/{quizId}/submit
```
**Headers:**
- `Authorization: Bearer {token}` (required)

**Request Body:**
```json
{
  "studentId": 1,
  "answers": {
    "1": "A named storage location",
    "2": "A mechanism to acquire properties from base class"
  }
}
```
**Response (200 OK):**
```json
{
  "quizId": 1,
  "studentId": 1,
  "totalQuestions": 2,
  "correctAnswers": 2,
  "score": 100,
  "submittedAt": "2026-02-28T11:00:00Z"
}
```

---

## 5. Enrollment Endpoints

### Enroll Student in Course
```
POST /api/enrollments
```
**Headers:**
- `Authorization: Bearer {token}` (required)

**Request Body:**
```json
{
  "studentId": 1,
  "courseId": 1
}
```
**Response (201 Created):**
```json
{
  "id": 1,
  "studentId": 1,
  "courseId": 1,
  "enrolledAt": "2026-02-28T10:30:00Z"
}
```
**Status Codes:** 201 Created, 400 Bad Request (already enrolled), 404 Not Found

---

### Get Student Enrollments
```
GET /api/enrollments/student/{studentId}
```
**Path Parameters:**
- `studentId` (long, required)

**Response (200 OK):**
```json
{
  "data": [
    {
      "id": 1,
      "studentId": 1,
      "courseId": 1,
      "course": {
        "id": 1,
        "title": "C# Basics",
        "description": "Learn C# fundamentals"
      },
      "enrolledAt": "2026-02-28T10:30:00Z"
    }
  ]
}
```

---

### Get Course Enrollments
```
GET /api/enrollments/course/{courseId}
```
**Path Parameters:**
- `courseId` (long, required)

**Response (200 OK):**
```json
{
  "data": [
    {
      "id": 1,
      "studentId": 1,
      "courseId": 1,
      "student": {
        "id": 1,
        "name": "John Doe",
        "email": "john@example.com"
      },
      "enrolledAt": "2026-02-28T10:30:00Z"
    }
  ]
}
```

---

### Unenroll Student
```
DELETE /api/enrollments/{enrollmentId}
```
**Headers:**
- `Authorization: Bearer {token}` (required)

**Response (204 No Content)**

---

## 6. Progress Endpoints

### Get Student Progress
```
GET /api/progress/student/{studentId}
```
**Query Parameters:**
- `courseId` (long, optional): Filter by course
- `completed` (boolean, optional): Filter by completion status

**Response (200 OK):**
```json
{
  "data": [
    {
      "id": 1,
      "studentId": 1,
      "lessonId": 1,
      "quizId": null,
      "completed": true,
      "quizScore": null,
      "lesson": {
        "id": 1,
        "title": "Variables and Data Types"
      }
    },
    {
      "id": 2,
      "studentId": 1,
      "lessonId": null,
      "quizId": 1,
      "completed": true,
      "quizScore": 85,
      "quiz": {
        "id": 1,
        "title": "Module 1 Quiz"
      }
    }
  ]
}
```

---

### Mark Lesson as Complete
```
POST /api/progress/lesson/{lessonId}/complete
```
**Headers:**
- `Authorization: Bearer {token}` (required)

**Request Body:**
```json
{
  "studentId": 1
}
```
**Response (201 Created):**
```json
{
  "id": 1,
  "studentId": 1,
  "lessonId": 1,
  "completed": true,
  "quizScore": null
}
```

---

### Record Quiz Progress
```
POST /api/progress/quiz/{quizId}/record
```
**Headers:**
- `Authorization: Bearer {token}` (required)

**Request Body:**
```json
{
  "studentId": 1,
  "quizScore": 85
}
```
**Response (201 Created):**
```json
{
  "id": 2,
  "studentId": 1,
  "quizId": 1,
  "completed": true,
  "quizScore": 85
}
```

---

### Get Course Progress Summary
```
GET /api/progress/course/{courseId}/summary
```
**Path Parameters:**
- `courseId` (long, required)

**Query Parameters:**
- `studentId` (long, optional): Get specific student's progress

**Response (200 OK):**
```json
{
  "courseId": 1,
  "totalLessons": 10,
  "completedLessons": 7,
  "totalQuizzes": 3,
  "completedQuizzes": 2,
  "averageQuizScore": 87.5,
  "progressPercentage": 70,
  "lastUpdated": "2026-02-28T11:30:00Z"
}
```

---

## Error Response Format

All endpoints return consistent error responses:

```json
{
  "statusCode": 400,
  "message": "Validation failed",
  "errors": [
    {
      "field": "email",
      "message": "Invalid email format"
    }
  ]
}
```

**Common Status Codes:**
- `200 OK` - Success
- `201 Created` - Resource created
- `204 No Content` - Success with no content
- `400 Bad Request` - Validation error
- `401 Unauthorized` - Missing/invalid token
- `403 Forbidden` - Insufficient permissions
- `404 Not Found` - Resource not found
- `409 Conflict` - Duplicate resource
- `500 Internal Server Error` - Server error

---

## API Base URL

```
http://localhost:5000/api
```

## Authentication

Most endpoints require JWT authentication. Include the token in the Authorization header:

```
Authorization: Bearer <your_jwt_token>
```

## Rate Limiting

- Standard API limits: 1000 requests per hour per IP
- Authentication endpoints: 10 requests per minute per IP

## Pagination

For endpoints that return lists, use pagination parameters:
- `page`: Page number (1-based, default: 1)
- `pageSize`: Number of items per page (default: 10, max: 100)

## Data Types

- `long`: 64-bit signed integer (database IDs)
- `int`: 32-bit signed integer
- `string`: Text data
- `boolean`: True/False
- `DateTime`: ISO 8601 format (UTC)
