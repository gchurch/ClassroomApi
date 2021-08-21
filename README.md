[![.NET](https://github.com/gchurch/ClassroomApi/actions/workflows/dotnet.yml/badge.svg)](https://github.com/gchurch/ClassroomApi/actions/workflows/dotnet.yml)

# ClassroomApi

I have implemented a classroom API using ASP.NET Core. I use EF Core to interact with an SQL Server database which stores the classroom data.

### Endpoint 1: Create a teacher

Send a post request to /api/Teachers with the teacher information in the body of the request. The response should contain a 201 Created status code and the body should contain the created teacher resource.

Example request body: 
{
    "firstName": "John",
    "lastName": "Smith",
    "age": 35,
    "subject": "Maths"
}

### Endopint 2: Create a student

Send a post request to /api/Students with the student information in the body of the request. If the student is succesfully created then the response will contain a 201 Created status code and the body should contain the created student resource. If the supplied ClassId doesn't exist then the response will contain a 204 No Content status code.

Example request body:
{
    "firstName": "David",
    "lastName": "Jones",
    "age": 12,
    "classId": 1
}

### Endpoint 3: Create a classroom

Send a post request to /api/Classes with the class information in the body of the request. The response should contain a 201 Created status code and the body should contain the created classroom resource.

Example request body:
{
    "className": "English",
    "school": "Oak High School",
    "grade": "A"
}

### Endpoint 4: Add a teacher to a classroom

Send a post request of the form /api/Classes/{classId}/Teachers/{teacherId}. If the classId or teacherId do not exist then the response will contain a 204 No Content status code. If the request was successful then the response body should contain the created TeacherClass resource.

Example URL: /api/Classes/3/Teachers/2

### Endpoint 5: Get all classroom names

Send a get request to /api/Classes/Names. The response body should contain a list of all classroom names.

### Endpoint 6: Get names of all students in a specific classroom

Send a get request of the form /api/Classes/{className}/StudentNames. The response body will contain the name of all students in that class.

Example URL: /api/Classes/Maths/StudentNames

### Endpoint 7: Get the details of all teachers of a student

Send a get request of the form /api/Students/{studentId}/Teachers. The response body will contain the details of all teachers of that student.

Example URL: /api/Students/1/Teachers
