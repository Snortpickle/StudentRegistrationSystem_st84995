# 🧩 FilterReset Module

Feature module for resetting student and course filters in the **Student Registration System**.

This module implements the reset-filter behavior using the **Command Pattern** while keeping the reset calculation pure, predictable, and independent from UI or database side effects.

---

## 📌 Purpose

The `FilterReset` module provides a clean way to reset active filters and return the UI to full student or course lists.

It supports the following user actions:

- `Show all students`
- `Show all courses`

These actions
