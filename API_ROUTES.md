# API Routes Documentation

This document lists all available API endpoints for the BioTech Backend microservices exposed via the API Gateway.

## Global Parameters
For list-returning endpoints, the following query parameters are supported for pagination:
- `page` (int, default: 1): The page number to retrieve.
- `pageSize` (int, default: 10): The number of items per page (max: 10).

---

## 1. AuthService
**Base URL**: `/api/Auth`

### Authentication
- `POST /login` - Authenticate a user and retrieve a JWT token.
- `POST /register` - Register a new user.
- `GET /profile` - Get current user profile (requires authentication).
- `PUT /profile` - Update current user profile (requires authentication).

### Farm Management
**Base URL**: `/api/farm`
- `POST /` - Create a new farm.
- `GET /{id}` - Get farm details by ID.

---

## 2. FeedingService
**Base URL**: `/api/v1/FeedingEvents`

### Endpoints
- `POST /` - Create a new feeding event.
- `GET /farm/{farmId}` - Get feeding events by Farm ID (paginated).
- `GET /batch/{batchId}` - Get feeding events by Batch ID (paginated).
- `GET /product/{productId}` - Get feeding events by Product ID (paginated).
- `GET /animal/{animalId}` - Get feeding events by Animal ID (paginated).
- `POST /recalculate-cost` - Recalculate total costs.
- `PUT /{id}/cancel` - Cancel (soft delete) a feeding event.

---

## 3. ReproductionService
**Base URL**: `/api/v1/Reproduction`

### Endpoints
- `POST /` - Create a new reproduction event.
- `GET /animal/{animalId}` - Get reproduction events by Animal ID (paginated).
- `GET /farm/{farmId}` - Get reproduction events by Farm ID (paginated).
- `GET /type/{type}` - Get reproduction events by Event Type (paginated).
- `GET /{id}` - Get a specific reproduction event by ID.
- `PUT /{id}/cancel` - Cancel (soft delete) a reproduction event.

---

## 4. HerdService
**Base URL**: `/api/v1`

### Animals
**Base URL**: `/api/v1/animals`
- `POST /` - Create a new animal.
- `POST /{id}/movements` - Register an animal movement.

### Batches
**Base URL**: `/api/v1/batches`
- `POST /` - Create a new batch.

### Breeds
**Base URL**: `/api/v1/breeds`
- `POST /` - Create a new breed.

### Categories
**Base URL**: `/api/v1/categories`
- `POST /` - Create a new category.

### Paddocks
**Base URL**: `/api/v1/paddocks`
- `POST /` - Create a new paddock.
- `GET /farm/{farmId}` - Get paddocks by Farm ID.

### Movement Types
**Base URL**: `/api/v1/movement-types`
- `POST /` - Create a new movement type.

---

## 5. CommercialService
**Base URL**: `/api`

### Transactions
**Base URL**: `/api/transactions`
- `POST /` - Create a new transaction.
- `GET /` - Get transactions (Filters: `farmId`, `fromDate`, `toDate`, `type`).
- `GET /{id}` - Get transaction details by ID.
- `GET /{id}/animals` - Get animals associated with a transaction.
- `GET /{id}/products` - Get products associated with a transaction.

### Third Parties
**Base URL**: `/api/third-parties`
- `POST /` - Create a new third party.
- `PUT /{id}` - Update a third party.
- `GET /` - Get third parties (Filters: `farmId`, `isSupplier`, `isCustomer`).
- `GET /{id}` - Get third party details by ID.

---

## 6. HealthService
**Base URL**: `/api/HealthEvent`

### Endpoints
- `POST /` - Create a new health event.
- `GET /farm/{farmId}` - Get health events by Farm ID (paginated).
- `GET /animal/{animalId}` - Get health events by Animal ID (paginated).
- `GET /batch/{batchId}` - Get health events by Batch ID (paginated).
- `GET /type/{type}` - Get health events by Event Type (paginated).

---

## 7. InventoryService
**Base URL**: `/api`

### Products
**Base URL**: `/api/Products`
- `POST /` - Create a new product.
- `GET /` - Get products by Farm ID (query param: `farmId`).
- `GET /low-stock` - Get low-stock products by Farm ID (query param: `farmId`).

### Inventory Items
**Base URL**: `/api/Inventory`
- `POST /` - Create a new inventory item.
- `GET /farm/{farmId}` - Get inventory items by Farm ID (paginated).

### Inventory Movements (Kardex)
**Base URL**: `/api/InventoryMovements`
- `POST /` - Register a new inventory movement.
- `GET /product/{productId}` - Get movements for a specific product (Kardex).
- `GET /farm/{farmId}` - Get all movements for a farm.

---

## Gateway Configuration
All routes are exposed through the API Gateway at `http://localhost:5000`.

### Authentication
Most endpoints require Bearer token authentication. Include the JWT token in the `Authorization` header:
```
Authorization: Bearer <your_jwt_token>
```

### Service Hosts
- **auth-service**: Port 8080
- **feeding-service**: Port 8080
- **reproduction-service**: Port 8080
- **herd-service**: Port 8080
- **commercial-service**: Port 8080
- **health-service**: Port 8080
- **inventory-service**: Port 8080
