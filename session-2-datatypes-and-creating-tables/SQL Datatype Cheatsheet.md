| **Type**                        | **Bytes**            | **PostgreSQL**            | **MySQL**        | **SQL Server**            | **SQLite**        | **Notes**                     |
| ------------------------------- | -------------------- | ------------------------- | ---------------- | ------------------------- | ----------------- | ----------------------------- |
| `TINYINT`                       | 1 byte               | -                         | ✅                | ✅                         | ✅ (as INTEGER)    | 0–255 (unsigned)              |
| `SMALLINT`                      | 2 bytes              | ✅                         | ✅                | ✅                         | ✅                 | 16-bit                        |
| `INT` / `INTEGER`               | 4 bytes              | ✅                         | ✅                | ✅                         | ✅                 | 32-bit                        |
| `BIGINT`                        | 8 bytes              | ✅                         | ✅                | ✅                         | ✅                 | 64-bit                        |
| `DECIMAL(p,s)` / `NUMERIC(p,s)` | Varies (p/2+1 bytes) | ✅                         | ✅                | ✅                         | ✅                 | Precise, slow. Use for money. |
| `FLOAT`                         | 4 bytes (single)     | ✅ (as `REAL`)             | ✅                | ✅                         | ✅                 | Approximate                   |
| `DOUBLE`                        | 8 bytes (double)     | ✅ (as `DOUBLE PRECISION`) | ✅                | ✅ (`FLOAT(53)`)           | ✅                 | Less rounding error           |
| `CHAR(n)`                       | n bytes              | ✅                         | ✅                | ✅                         | ✅                 | Fixed-length                  |
| `VARCHAR(n)`                    | n+1 bytes approx.    | ✅                         | ✅                | ✅                         | ✅                 | Variable-length               |
| `TEXT`                          | Varies (large)       | ✅                         | ✅                | ✅ (`VARCHAR(MAX)`/`TEXT`) | ✅                 | Use for long text             |
| `DATE`                          | 4 bytes              | ✅                         | ✅                | ✅                         | ✅                 | YYYY-MM-DD                    |
| `TIME`                          | 3–5 bytes            | ✅                         | ✅                | ✅                         | ✅                 | hh\:mm\:ss                    |
| `DATETIME`                      | 8 bytes              | ✅ (`TIMESTAMP`)           | ✅                | ✅                         | ✅                 | Date + time                   |
| `BOOLEAN`                       | 1 byte               | ✅                         | ✅ (`TINYINT(1)`) | ✅ (`BIT`)                 | ✅ (`INTEGER 0/1`) | True/false                    |
