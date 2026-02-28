#!/usr/bin/env bash
# Inspect PostgreSQL: list databases and lms-db tables/columns
# Usage: ./inspect-db.sh   (uses defaults below)
# Or:    PGHOST=localhost PGPORT=5432 PGUSER=postgres PGPASSWORD=password ./inspect-db.sh

PGHOST="${PGHOST:-localhost}"
PGPORT="${PGPORT:-5432}"
PGUSER="${PGUSER:-postgres}"
export PGPASSWORD="${PGPASSWORD:-password}"

echo "=== List all databases ==="
psql -h "$PGHOST" -p "$PGPORT" -U "$PGUSER" -d postgres -c "\l"

echo ""
echo "=== Connect to lms-db and list tables ==="
psql -h "$PGHOST" -p "$PGPORT" -U "$PGUSER" -d lms-db -c "\dt"

echo ""
echo "=== Describe 'Users' table (if exists) ==="
psql -h "$PGHOST" -p "$PGPORT" -U "$PGUSER" -d lms-db -c "\d \"Users\""

echo ""
echo "=== Describe 'users' table (snake_case, if exists) ==="
psql -h "$PGHOST" -p "$PGPORT" -U "$PGUSER" -d lms-db -c "\d users"

echo ""
echo "=== List tables in public schema ==="
psql -h "$PGHOST" -p "$PGPORT" -U "$PGUSER" -d lms-db -c "SELECT table_name FROM information_schema.tables WHERE table_schema = 'public' ORDER BY table_name;"
