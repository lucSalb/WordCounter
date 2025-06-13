# WordCounterAPI

**API for counting words in a `.txt` file sent by the client.**
---

## Functionality

The API receives a '.txt' file through a **multipart/form-data** request and returns a JSON structure with found workds and how many times each word appeared. 

---

## Request structure

**Endpoint:** 🟢 **[POST]** `/api/wordcount`

**Content-Type:** `multipart/form-data`

**Parameters:**

| Name         | Type       | Mandatory   | Description                      |
|--------------|------------|-------------|----------------------------------|
| textDocument | `IFormFile`| ✅         | .txt files with the text.         |

> ONLY '.txt' files are allowed.

