# Rate

## Create Rating

```http
POST /rate
```

```json
{
  "movieID": "00000000-0000-0000-0000-000000000000",
  "userID": "00000000-0000-0000-0000-000000000000",
  "rating": 5,
  "comment": "This is a great movie"
}
```

### Create Rating Response

```js
200 OK
```

```json
{
  "status": "Rating successfully created."
}
```

or

```js
400 Bad Request
```

```json
{
  "status": "Rating already created."
}
```

## Get All Movie Rating

```http
GET /rate/movie/{id}
```

### Get All Movie Rating Response

```js
200 OK
```

```json
{
  "ratings": [
    {
      "userId": "00000000-0000-0000-0000-000000000000",
      "rate": 5,
      "comment": "This is a great movie"
    }
  ]
}
```

or

```js
404 Not Found
```

## Get All User Rating

```http
GET /rate/user/{id}
```

### Get All User Rating Response

```json
{
  "ratings": [
    {
      "userId": "00000000-0000-0000-0000-000000000000",
      "rate": 5,
      "comment": "This is a great movie"
    }
  ]
}
```

or

```js
404 Not Found
```

## Delete Rating

```http
DELETE /rate
```

```json
{
  "movieID": "00000000-0000-0000-0000-000000000000",
  "userID": "00000000-0000-0000-0000-000000000000",
  "rating": 5,
  "comment": "This is a great movie"
}
```

### Delete Rating Repsonse

```js
204 No Content
```

or

```js
404 Not Found
```
