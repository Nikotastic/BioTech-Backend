<div align="center">

# 🧬 BioTech-Backend

### BioTech Project Backend developed in .NET

![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![PostgreSQL](https://img.shields.io/badge/PostgreSQL-316192?style=for-the-badge&logo=postgresql&logoColor=white)

---

</div>

## 📋 Table of Contents

- [📌 Project Guidelines](#-project-guidelines)
- [🌳 Git Flow - Branch Convention](#-git-flow---branch-convention)
- [🧩 Commit Convention](#-commit-convention)
- [📘 Important Information](#-important-information)

---

## 📌 Project Guidelines

This repository contains the **BioTech project backend** developed in **.NET**.

> ⚠️ **The entire team must follow these branch and commit conventions mandatorily.**

---

## 🌳 Git Flow - Branch Convention

### 🎯 Main Branches


| Branch    | Purpose         | Description                           |
| --------- | --------------- | ------------------------------------- |
| `main`    | **Production**  | Stable version deployed in production |
| `develop` | **Development** | Integration of new functionalities    |

---

### 🔀 Working Branches

| Branch Type | Nomenclature           | Purpose                               |
| ----------- | ---------------------- | ------------------------------------- |
| **Feature** | `feature/feature-name` | New backend functionalities           |
| **Hotfix**  | `hotfix/fix-name`      | Critical fixes in production          |
| **Release** | `release/vx.x.x`       | Version preparation before production |

---

### 💡 Branch Examples

```bash
# Features
feature/api-usuarios
feature/autenticacion
feature/eventos

# Hotfixes
hotfix/error-en-login

# Releases
release/v1.0.0
```

---

### ⚡ Git Flow Rules

<table>
<tr>
<td>

**📌 Rule 1**

> Each sprint task must have its own `feature/` branch

</td>
</tr>
<tr>
<td>

**🔥 Rule 2**

> `hotfix/` branches fix directly on `main` and then sync with `develop`

</td>
</tr>
<tr>
<td>

**📦 Rule 3**

> `release/` branches come from `develop` and return to `main` and `develop`

</td>
</tr>
</table>

---

## 🧩 Commit Convention

### 📝 Mandatory Format

```
<type>(<area>): <brief description>
```

> 💡 **Note:** The description must be short and in lowercase

---

### 🏷️ Allowed Commit Types

<table>
<thead>
<tr>
<th width="15%">Type</th>
<th>Usage</th>
</tr>
</thead>
<tbody>
<tr>
<td><code>feat</code></td>
<td>New functionality or endpoint</td>
</tr>
<tr>
<td><code>fix</code></td>
<td>Bug fix</td>
</tr>
<tr>
<td><code>docs</code></td>
<td>Documentation</td>
</tr>
<tr>
<td><code>style</code></td>
<td>Formatting without affecting logic</td>
</tr>
<tr>
<td><code>refactor</code></td>
<td>Code improvement or reorganization</td>
</tr>
<tr>
<td><code>test</code></td>
<td>Unit / integration tests</td>
</tr>
<tr>
<td><code>chore</code></td>
<td>Configuration, migrations, dependencies</td>
</tr>
<tr>
<td><code>revert</code></td>
<td>Revert commits</td>
</tr>
</tbody>
</table>

---

### 📌 Commit Examples

```bash
#  New functionality
feat(api): crea endpoint para registro de usuarios

#  Bug fix
fix(database): corrige error en conexión SQL

#  Tests
test(services): agrega pruebas para UserService

#  Documentation
docs(readme): actualiza guía de instalación

#  Refactoring
refactor(controllers): optimiza UserController
```

---

## 📘 Important

> 🔴 **These rules are MANDATORY for all team members.**

### 📞 Contact

- 💬 Any questions should be consulted with the **Scrum Master**
- 📢 Report blockers in the daily standup
- 📝 Document important decisions in the project

---

<div align="center">

### 🌟 Thank you for contributing to the BioTech project!

**Made with ❤️ by the development team**

[![GitHub](https://img.shields.io/badge/GitHub-100000?style=for-the-badge&logo=github&logoColor=white)](https://github.com)

---

© 2025 BioTech. All rights reserved.

</div>
