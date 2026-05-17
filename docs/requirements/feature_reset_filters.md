# Feature: Reset Student and Course Filters

## User Story

As a user, I want to reset active student and course filters so that I can quickly return to the full list without manually clearing each field.

## Acceptance Criteria

### AC1: Reset student filters

Given the student list has one or more active filters  
When the user clicks the "Show all students" button  
Then all student filter fields are cleared and the full student list is displayed

### AC2: Reset course filters

Given the course list has one or more active filters  
When the user clicks the "Show all courses" button  
Then all course filter fields are cleared and the full course list is displayed

### AC3: No data loss

Given the user clicks a reset filter button  
When the list is refreshed  
Then no student, course, or enrollment data is deleted or modified