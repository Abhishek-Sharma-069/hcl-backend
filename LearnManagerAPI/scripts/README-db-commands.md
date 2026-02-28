# PostgreSQL inspection commands for lms-db

Use these to verify database name, tables, and the `Users` table structure.

## One-liner: list databases

```bash
PGPASSWORD=password psql -h localhost -p 5432 -U postgres -d postgres -c "\l"
```

## One-liner: list tables in lms-db

```bash
PGPASSWORD=password psql -h localhost -p 5432 -U postgres -d lms-db -c "\dt"
```

## One-liner: describe Users table (PascalCase)

```bash
PGPASSWORD=password psql -h localhost -p 5432 -U postgres -d lms-db -c "\d \"Users\""
```

## One-liner: describe users table (snake_case)

```bash
PGPASSWORD=password psql -h localhost -p 5432 -U postgres -d lms-db -c "\d users"
```

## Run the full inspection script

From the project root:

```bash
cd /home/abhishek-sharma/Desktop/Hcl/hcl-backend2/LearnManagerAPI
./scripts/inspect-db.sh
```

Or with custom connection (same as appsettings):

```bash
PGHOST=localhost PGPORT=5432 PGUSER=postgres PGPASSWORD=password ./scripts/inspect-db.sh
```

## Expected schema for register to work (with snake_case naming)

After the fix, EF Core expects the table **`users`** (lowercase) with columns:

- `id` (bigint, PK)
- `name` (text)
- `email` (text), unique
- `password_hash` (text)
- `role` (text)
- `created_at` (timestamp)

If your table is named `Users` with PascalCase columns, either rename it/columns to snake_case, or we can remove the snake_case convention and match your current schema.
