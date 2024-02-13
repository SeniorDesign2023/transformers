Status Update 3

-----
- **Recap:**

Whole group started actually working on the project. On the frontend side, the app was created, configured and pushed up to the GitHub. Then some data flow processes were stubbed out. Finally research was put into choosing a good graphing API. Once an API (Plotly.Blazor) was chosen it was configured into the app. On the backend we created the pre-computed Hadamard matrices and realized we could forgo creating the Walsh matrices by improving the generation algorithm.

- **Tasks completed**
  - Description of tasks completed (and by whom)
    - General**:** Worked on getting everything into one solution. Each member was researching their coming work and keeping up with the team’s progress.
    - Derik: Worked on presentation and JSON output. 
    - Kain: Assisted with researching and programming the backend, mostly with generating Hadamard matrices for this portion. 
    - Chet: Researched API options, generating audio snippets for use in testing/presentation 
    - Calvin: Created the Hadamard matrix generation code.
    - Finn: Worked on setting up various parts of the application. Created and configured MAUI Blazor app. Set up a template version of a data model/service for using the data in the front end. Worked with Derik and Chet to figure out a good graphing API. Eventually settled on Plotly.Blazor which was then configured in the app and several simple examples created.
  - Metrics:
    - Meeting Count: 4
    - Approximate lines of code: 249
    - PRs Completed: 4
- **Successes**
  - Accomplishments:
    - App creation
    - Chose a graphing API
    - Hadamard Matrix generation
    - JSON output
  - Solutions (Things we did that solved a problem):
    - Base Plotly was difficult to integrate in a Blazor environment so we figured out how to use the Plotly.Blazor library in its place.
    - Created a Hadamard generation algorithm that seems to be working correctly out to human-testable dimensions. 
  - Things we tried that didn’t work:
    - ` `Base Plotly was not as cooperative as expected, found a more integrated library.
    - Found that we do not need to actually generate and store the Walsh matrices, only needed to save the number of “flips” between 1 and -1 to store the related indices of the Walsh matrix.
- **Roadblocks/challenges**
  - Current challenges:
    - We will be limited in the number of data points we can process at a time if we cannot generate and work with larger matrices. This will not be an issue for the MVP but could be interesting to see what we can do with large matrices.
  - Challenges overcome:
    - The largest hurdle we were expecting was the Hadamard generation so now that it is implemented, we should be able to focus on completing the MVP.
  - Challenges remaining:
    - Larger Hadamard matrices would be useful. 
    - Implement the transform algorithm now that we have the matrices
    - Create a Plotly graph component to display the results of both the transforms and the original data
    - Implement File I/O
  - Help Needed:
    - We could utilize access to more powerful hardware. At the current power of our laptops, we could expect to process data in small chunks (maybe 1/10  to ½ of a second of CD-quality audio) but with better hardware we could process around one million data points since we could generate and work with larger matrices. This would change the possible applications for this app but not the MVP so it is a stretch-goal for now.
- **Changes/Deviations**

No significant changes but we are going to use a Blazor-integrated Plotly library instead of native Plotly. We will also not be generating the Walsh matrices directly, but rather be calculating the number of flips and generating a mapping-array to store with the related Hadamard matrix.

- **Next 3 Weeks:**

On the frontend we should have base data input and visualization fully implemented in the next three weeks. There will most likely be room to expand both these areas but we should focus on having an MVP version of these aspects completed in this time. In addition the data flow of the whole app should be implemented to some degree. Meaning The user should be able to upload data, that data should be processed through the API and sent to the backend and the backend should be able to send it back through the API to the frontend where it will be visualized. For the backend we will need to double-check that our generation algorithm is correct. The Graphing API should  start taking shape in the form of defining interactions between the back and frontend.

- **Confidence** on completion of the project for each team member and the group average
  - Derik: 5 for the MVP, 3.5 for stretch goals
  - Finn: 4
  - Calvin: 5
  - Kain: 90% (4.5)
  - Chet: 5
  - Average: 4.7 
