# RecruitmentTask
## Examples of usage

### To analyse a triangle
```
RecruitmentTask.App.exe analyse-triangle <side A> <side B> <side C>
```

```
RecruitmentTask.App.exe at <side A> <side B> <side C>
```
Example:
```
RecruitmentTask.App.exe analyze-triangle 2 2 4
RecruitmentTask.App.exe at 2 2 4
```

### To count words in files
```
RecruitmentTask.App.exe count-words <path to file 1> <path to file 2> <...>
```
```
RecruitmentTask.App.exe cw <path to file 1> <path to file 2> <...>
```
Example:
```
RecruitmentTask.App.exe count-words C:/marta/files/file1.txt C:/marta/files/file2.txt
RecruitmentTask.App.exe cw C:/marta/files/file1.txt C:/marta/files/file2.txt
```

**Remark**: Words in files are compared case-sensitive by default. If you want to perform case-insensitive comparison, you have to add argument `--case-insensitive`, or `-i`, for example:

```
RecruitmentTask.App.exe count-words C:/marta/files/file1.txt C:/marta/files/file2.txt --case-insensitive
RecruitmentTask.App.exe cw C:/marta/files/file1.txt C:/marta/files/file2.txt -i
```
