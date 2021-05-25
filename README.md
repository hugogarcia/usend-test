# USend Test Project
A simple project made with .NET 5. It can create, read or update a user.
It uses an In-Memory Database, populating with one user to use in the authentication operation the first time.

Request the bearer token with this data the first time:
```javascript
{
  "email": "admin@email.com",
  "password": "123456789"
}
```