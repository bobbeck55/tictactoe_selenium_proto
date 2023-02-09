
SELENIUM Automated Testing with Percy Snapshots
of REACT TicTacToe app
===============================================

1. RUN BASE TEST

Window 1: Start Tictactoe app
cd tictactoe_react_proto
git checkout master
npm start

Window 2: Run Selenium automated test
cd tictactoe_selenium_proto
git checkout master
set PERCY_TOKEN=<see percy.io Project settings>
set PERCY_BRANCH=master
percy exec -- dotnet test --no-restore

2. RUN BASE TEST WITH UPDATE TO APP SRC CODE to
guarantee mismatch AUTOMATED TEST

Window 1: Make update to react app
cd tictactoe_react_proto
git checkout master
change src code
npm start

Window 2: Run Selenium automated test
set PERCY_BRANCH=local
percy exec -- dotnet test --no-restore

FAQ -
1. working sample test - build #138 at percy.io

