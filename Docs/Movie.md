# Movie

## Create Movie

```http
POST /movie
```

```json
{
  "name": "Avatar",
  "director": "James Cameron",
  "release": "2009-12-18"
}
```

### Create Movie Response

```js
201 Created
```

```yml
Location: {host}/Movie/{id}
```

```json
{
  "id": "00000000-0000-0000-0000-000000000000",
  "name": "Avatar",
  "director": "James Cameron",
  "release": "2009-12-18"
}
```

## Get Movie

```http
GET /movie/{id}
```

### Get Movie Response

```js
200 OK
```

```json
{
  "id": "00000000-0000-0000-0000-000000000000",
  "name": "Avatar",
  "director": "James Cameron",
  "release": "2009-12-18"
}
```

or

```js
404 Not Found
```

## Delete Movie

```http
DELETE /user/{id}
```

### Delete Movie Repsonse

```js
204 No Content
```

or

```js
404 Not Found
```
