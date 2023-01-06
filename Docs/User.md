# User

## Create User

```http
POST /user
```

```json
{
  "email": "user@email.com",
  "username": "username",
  "password": "password"
}
```

### Create User Response

```js
201 Created
```

```yml
Location: {host}/User/{id}
```

```json
{
  "id": "00000000-0000-0000-0000-000000000000",
  "email": "user@email.com",
  "username": "username"
}
```

## Get User

```http
GET /user/{id}
```

### Get User Response

```js
200 OK
```

```json
{
  "id": "00000000-0000-0000-0000-000000000000",
  "email": "user@email.com",
  "username": "username"
}
```

or

```js
404 Not Found
```

## Delete User

```http
DELETE /user/{id}
```

### Delete User Repsonse

```js
204 No Content
```

or

```js
404 Not Found
```
