# DekamikCrud

A simple CRUD-helper for rapid API development.

## Entity types

The package supports two types of entities.

### BaseEntity

Normal database entities with ID.

### TimestampedEntity

Database entities with ID, aswell as CreatedAt and UpdatedAt timestamps.

## Repository types

The package supports three repository types, adressing different needs.

### Repository

Normal CRUD repository for BaseEntities.

### ReadOnlyRepository

Read-only repository for any entity type.

### TimestampedRepository

CRUD repository for TimestampedEntities. Automatically timestamps during create and update.
