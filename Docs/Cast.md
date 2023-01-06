# Cast

## Create Cast

```http
POST /cast
```

```json
{
  "movieID": "00000000-0000-0000-0000-000000000000",
  "actor": "Zoe Saldana",
  "role": "Neytiri"
}
```

### Create Cast Response

```js
200 OK
```

```json
{
  "status": "Successfuly added a cast member."
}
```

## Get Cast

```http
GET /cast/{movie_id}
```

### Get Cast Response

```js
200 OK
```

```json
{
  "cast": [
    {
      "actor": "Zoe Saldana",
      "role": "Neytiri"
    }
  ]
}
```

or

```js
404 Not Found
```

## Delete Cast

```http
DELETE /cast
```

```json
{
  "movieId": "00000000-0000-0000-0000-000000000000",
  "actor": "Sam Worthington",
  "role": "Jake Sully"
}
```

### Delete Cast Repsonse

```js
204 No Content
```

or

```js
404 Not Found
```
