# ClassroomApi

[![.NET](https://github.com/gchurch/ClassroomApi/actions/workflows/dotnet.yml/badge.svg)](https://github.com/gchurch/ClassroomApi/actions/workflows/dotnet.yml)


Endpoint 1: Create a teacher

Send a post request to /api/Teachers with the teacher information in the body of the request.

Endopint 2: Create a student

Send a post request to /api/Students with the student information in the body of the request. If the supplied ClassId doesn't exist then the response will contain a 204 No Content status code.

Endpoint 3: Create a classroom

Send a post request to /api/Classes with the class information in the body of the request.

Endpoint 4: Add a teacher to a classroom

Send a post request of the form api/Classes/{classId}/Teachers/{teacherId}. If the classId or teacherId do not exist then the response will contain a 204 No Content status code.

endpoint 5: Get all classroom names

Send a the get request to api/Classes/Names.
