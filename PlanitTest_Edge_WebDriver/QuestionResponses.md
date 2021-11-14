# Questions
## What other possible scenario’s would you suggest for testing the Jupiter Toys application

I have created empty tests that have titles that give areas that identify what aspects should receive further testing.  These tests are marked as inconclusive.  The Actual details of the required tests will need to be more fully expanded.

Additional there are a number of tests that have failed, I believe due to being coded to fail.

There are 21 tests defined 
- 6 which are skipped due to being outside the scope of the test.
- 3 that fail due to bugs in the code, or undefined acceptance requirements
- 12 that pass.

## Jupiter Toys is expected to grow and expand its offering into books, tech, and modern art. We are expecting the of tests will grow to a very large number.
Webdriver tests are by their nature and the nature of the tool fragile, Small unimportant changes that alter the DOM will often cause this approach to result in high overheads in maintance.

This project has been written in such away that where possible there are no magic strings in the actual tests themselves, but these are stored in various helpers. An addtional benefit of this approch is that IDE / Complier will highlight typing mistakes.  It also reduce the chances of copied code problems by only having one place that the various functions live so that if there is a required change then there is only the one instance to be modified.

Where the DOM needs to be exploded to determine various values the functions have been removed from test file to a models file for each page within the SPA.  This means that it is easy to call these methods in multiple tests while not cluttering the actual test file with support functions.
### What approaches could you used to reduce overall execution time

Webdriver tests by their basic nature are slow tests as they don't mock and require the initiation and disposal of the various browsers that the tests run on.  

My solution is that many of these tests could be pulled from a intergration test framework like webdriver to unit test frameworks such as JEST, Jasmine, Mocha etc.

Spliting the tests in this way where tests that need to interact with the browser, and are required for determination of performance etc are run via the webdriver. While the tests that can be written on pure functions, that are independant of routing etc can live within the Ubit Test framework.

### How will your framework cater for this
By Spliting the tests from the supporting functions, and the hiding the magic strings in helpers. Results in only requiring one change even when the function or magic string is used in multiple places.

The greatest benefits in expanding testing will be in adding ID's to the DOM, and moving as many as possible of the tests to a Typescript unit test product.

### Describe when to use a BDD approach to automation and when NOT to use BDD

BDD is an approach to testing that was designed as part of a method to improve the communication between the developers and the users / Subject Matter Experts.

This means that it is a good fit for the happy path testing that SME's, BA's, Solution Archiect's, or Project/Delivery Manger's use to judge the completeness of a project.   

There are two problems that reduce the benefits, and will determine if it is a suitable approach. 
- There is considerable work required to write the code-behind in such frameworks.  It is particular hard to write the code-behind in such away that the BDD scenerios are extensable.  Each new feature still requires new code-behind and often refactoring of the current tests.
- The additional layer of the BDD Framework is yet another performance cost.

I have been successful at implementing such a framework "Fitnesse" however the solution was aimed at testing independant classes rather than the application as whole.

If the aim of introducing BDD is to increase the number of tests that are written, by moving the testing from the QA Team to the BA / SME team. The additional development costs of the code-behind and the lack of sad path testing will most likely have a reduced impact on the quaility gate. If however the purpose is to improve the communication between the developement team and the SME in particular then benefits are considerable.

So there is not a one-size fits all approach to BDD. 

# Notes and recommendations
1. The current application is largely as fragile as it is becuase there are very few ID's used within the DOM.  This results in accessing most parts of the DOM via CSS, XPath, and TagName.  If the code was refactored so that most if not all fields have explict ID the developed framwork will be more usable.
2. Spliting the test approach so that much of the code can be tested via a Typescript Unit test platform will improve performance.
