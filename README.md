# School Subjects Information System
This console application manages informations about school subjects, allowing users to view details from a predefined list and fetch additional data from an external API.

##  Features
*  Display a list of subjects with basic information.
*  Select a subject to view detailed information including literature used and additional properties.
*  Load initial subject data from a JSON file.
*  Fetch additional subjects dynamically from an external API.

##  Requirements
###  Subject Properties
*  The app should allow the user to choose from a prefdefined list of subjects.
*  Every subject should have the following:
    *  Name: The name of the subject.
    *  Description: A brief description of the subject.
    *  Number of Weekly Classes: Indicates how many classes are held per week for this subject.
    *  Literature Used: List of literature materials used for the subject. Multiple entries allowed.
    *  Additional Properties: Optional, type-specific properties that may vary depending on the subject.
###  Functionality
*  Display List of Subjects: Show all subjects available with their names and basic details.
*  Select a Subject: Allow users to choose a subject from the list to view detailed information.
*  Load Subject Data from a File: Initial subject data is loaded from a JSON file stored locally.
*  Feetch Additional Subjects: Retrieve additional subject information from an external API to expand the available subjects dynamically.
*  Display Subject Details: Present comprehensive details including literature used and any additional properties for the selected subject.

##  UseCases:
*  Load Subjects from file
*  Load Subjects from Api
*  Display the list of Subjects
*  Select a Subject to view details
*  Display detailed information about that Subject

##  Diagrams:
###  (UseCase)
![UseCase1](https://github.com/MarkoSimka/SchoolSubjectApp/assets/63017129/c2ba3987-393b-49b5-bd21-764d25110225)

###  (Class Diagram)
![ClassDiagram](https://github.com/MarkoSimka/SchoolSubjectApp/assets/63017129/03572da6-8621-4440-8359-54924eab3c9c)

##  Getting Started
To get started with this project, follow these steps:

1.Clone the repository:

    https://github.com/MarkoSimka/SchoolSubjectApp.git //https

    git@github.com:MarkoSimka/SchoolSubjectApp.git //ssh

2.Setup:
*  Ensure .NET Core SDK is installed.
*  Place your subject data JSON file (subjects.json) in the project directory.

3.Run the Application:
```
dotnet run
```

4.Interact with the Application:
*  Follow the prompts to view subjects and their details.
*  Select a subject to explore its comprehensive information.

##  JSON File Format (subjects.json)
The subjects.json file should adhere to the following structure for each subject:
```
[
  {
    "Name": "Mathematics",
    "Description": "Fundamental concepts in mathematics.",
    "NumberOfWeeklyClasses": 5,
    "LiteratureUsed": ["Mathematics for Beginners", "Advanced Calculus"],
    "AdditionalProperties": {
      "Teacher": "Mr. Smith",
      "Room": "301",
      "GradeLevel": "Grade 10"
    }
  },
  {
    "Name": "Science",
    "Description": "Basic principles of science.",
    "NumberOfWeeklyClasses": 4,
    "LiteratureUsed": ["Science Explained", "Biology Essentials"],
    "AdditionalProperties": {
      "Teacher": "Ms. Johnson",
      "Room": "202",
      "GradeLevel": "Grade 11"
    }
  }
]

```

##  Contributing
Contributions are welcome! If you have any ideas, enhancements, or bug fixes, feel free to open an issue or submit a pull request.

Happy coding!
