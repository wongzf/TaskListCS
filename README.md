# WZF Task List

This is my Simple Task List Application for the technical interview. The application is implemented in C# and written/made in Visual Studio 2022.

The following basic features are completed:
* Users able to add tasks to the list, including a task name and a due date.
* Users able to view a list of all tasks, displaying their names and due dates.
* Users able to mark tasks as completed, which should update the task's status.

The following bonus/optional features are completed:
* Users can delete tasks.
* Sorting by Due Date or Completion Status
* Color-coding for Task Status (Red for incomplete and Green for complete)

## Instructions on Building EXE
1. Open TaskListCS.sln in Visual Studio
2. Change "Debug" to "Release"

![Screenshot 2024-10-22 101746](https://github.com/user-attachments/assets/29b7fc69-14df-4acc-a20e-a58edd200e77)

3. Go to Build > Build TaskListCS

![Screenshot 2024-10-22 101802](https://github.com/user-attachments/assets/9890ae59-bfb0-4afc-a27d-ff03fe9a9cd9)

4. Open project folder in file explorer.
5. Go to TaskListCS > bin > Release > net8.0 > TaskListCS.exe
6. Run TaskList.exe

## Instructions for using program

![Screenshot 2024-10-22 103132](https://github.com/user-attachments/assets/09ce5049-bd3a-40d9-9ce0-15687076cf7d)

### Adding Task
1. Input '1' and press 'Enter'
2. Answer each prompt one by one

![Screenshot 2024-10-22 103254](https://github.com/user-attachments/assets/12db5d56-0843-41d5-a959-25baa77dc7b6)

3. New Task should be added to Task List

![Screenshot 2024-10-22 103320](https://github.com/user-attachments/assets/dae8cde4-59cc-4a47-82ae-9f6694e8991d)

### Changing Task Status
1. Input '2' and press 'Enter'
2. Task List will be reprinted with a number assigned.

![Screenshot 2024-10-22 104921](https://github.com/user-attachments/assets/b12b8647-971b-45c2-9d58-1f60df071c56)

3. Enter the coresponding number for the task you wish to change the status of
4. Status of selected task should be changed.

![Screenshot 2024-10-22 104803](https://github.com/user-attachments/assets/d3169185-49a9-468e-b4c2-2d2d000f842a)

### Sorting Task by Completion Status
1. Input '4' and press 'Enter'
2. Task should now be sorted by their completion status, "Incomplete" first, followed by "Complete"

![Screenshot 2024-10-22 105511](https://github.com/user-attachments/assets/373625ea-5a2c-4f69-a0bc-a4e4e96ca8f8)

### Sorting Task by Due Date
1. Input '5' and press 'Enter'
2. Task should now be sorted by their due dates, earliest first.

![Screenshot 2024-10-22 112300](https://github.com/user-attachments/assets/8ec31223-a837-40dd-8f69-d29ce510b682)

### Deleting a Task
1. Input '3' and press 'Enter'
2. Task List will be reprinted with a number assigned.
3. Enter the number of the task you wish to delete.
4. You will be prompted with a confirmation, answer with "Y".

![Screenshot 2024-10-22 112824](https://github.com/user-attachments/assets/99ad5055-0537-4aab-aa23-5ffbf649fa1b)

5. Selected task should now be removed from the tasklist.

![Screenshot 2024-10-22 112941](https://github.com/user-attachments/assets/b7db3607-673e-4f47-aa99-ca455f3b7f3f)

## Testing
Potential Issues/edge cases will be documented here.

| Problem    |  User inputs a number that is out-of-bounds (OOB) in any menu. E.g. User enters "79" in Main Menu or Status change menu.|
| -------- | ------- |
| Solution  |  Prompt will be displayed if OOB input is detected and asks user to try again.  |

| Problem    |  User doesn't enter any text for the task text and leaves it blank.|
| -------- | ------- |
| Solution  |  Prompt will be displayed to inform users that task text cannot be blank and to try again.  |





