Status Update 4

-----
- **Recap:**

We wanted to get the MVP done and we effectively did that this sprint. We started with creating the API code to connect the backend “engine” to the frontend graphing. After some testing we realized we should add a configuration file and settings page. Now we are figuring out what other pages we want to add and what other functionality is needed to make those pages function. We spent a fair amount of time fixing up our style to match the C# standards. Mostly capital-camelcase for the functions and lower camel for the class members.

- **Tasks completed**
  - Description of tasks completed (and by whom)
    - General**:** We all gave comments on and thought about how to present this work now that it is beginning to come together.
    - Derik: General coding guidance. Started working on our presentation and double checked the math. Worked out how to test the matrices. Continuing algorithm research for stretch goals.
    - Kain: Audio recordings and presentation feedback. Algorithm research.
    - Chet: Setup the API service to take data from the view and run the transform functions.
    - Calvin:  Finished writing the algorithms to compute both the Walsh and Hadamard transforms.Renamed functions to fit C# style. Worked with Chet and Finn to connect to the front end.
    - Finn:Implemented the pages to input or upload data and worked with Chet to connect them with the API. Set up the configuration file and implemented the Settings page.
  - Metrics:
    - Meeting Count: 8
    - Approximate lines of code: 568 
    - PRs Completed: 11
- **Successes**
  - Accomplishments:
    - Connected the front and back end with the API
    - Can now accept json input given a Path
    - Transforms have been tested and we are confident that they are accurate
    - Settings page and configuration setup
    - Style fixed
  - Solutions (Things we did that solved a problem):
    - Figured out that the appsettings functionality is not supported in Maui so Finn created a configuration class.
    - Style was not consistent so we decided to follow the C# conventions
    - We happened to discover that we can test our matrices for correctness by inputting a repeating [1,0,1,0…] signal. This results in an output that is easily predictable and testable,
  - Things we tried that didn’t work:
    - “Appsettings” was not supported, lost a few hours on that one.
    - Our initial presentation strategy was still pretty verbose so we are coming at it from a different direction now.
- **Roadblocks/challenges**
  - Current challenges:
    - How do we explain this well for the presentation?
    - What other pages do we need to add to demonstrate the use of this application?
    - What stretch goal should we start looking at next, Polyphonic tuner? FFT?
  - Challenges overcome:
    - Appsettings was an important one since we now have access to useful configuration information.
    - API connected the front and backends 
    - Matrix  testing is possible now
  - Challenges remaining:
    - Condense an explanation down to an elevator pitch, lots of iterations
    - Work on the UI, add styles and improve layout/navigation
  - Help Needed:
    - We still want to try some calculations on a larger machine but might want to see what we get done this sprint before focusing on that.
- **Changes/Deviations:**

No major deviations other than picking stretch goals now. Adding configuration is new.

- **Next 3 Weeks:**
  - Flesh out UI/UX
  - Add navigation
  - Pick next algorithm so we can get prepared to implement it
  - Rough presentation outline
  - Start running real data through our app.
- **Confidence** on completion of the project for each team member and the group average
  - Derik: 5
  - Finn: 5
  - Calvin: 5
  - Kain: 5
  - Chet: 5
  - Average:5  
