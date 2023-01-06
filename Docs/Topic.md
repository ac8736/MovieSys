# Topic

## Create Topic

```http
POST /topic
```

```json
{
  "movieID": "00000000-0000-0000-0000-000000000000",
  "topic": "Fantasy"
}
```

### Create Topic Response

```js
200 OK
```

```json
{
  "topic": "Art"
}
```

or

```js
400 Bad Requst
```

```json
{
  "status": "Topic already created."
}
```

## Get Topics

```http
GET /topic/{id}
```

### Get Topics Response

```js
200 OK
```

```json
{
  "topics": [
    {
      "topic": "Fantasy"
    },
    {
      "topic": "Sci-Fi"
    }
  ]
}
```

or

```js
404 Not Found
```

## Delete Topic

```http
DELETE /topic
```

```json
{
  "movieID": "00000000-0000-0000-0000-000000000000",
  "topic": "Fantasy"
}
```

### Delete Topic Repsonse

```js
204 No Content
```

or

```js
404 Not Found
```
