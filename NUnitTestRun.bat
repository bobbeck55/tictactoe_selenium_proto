REM Run the selected tests
REM %1 - "all" or "test name"

set PERCY_BRANCH=master
set PERCY_TOKEN=16d6c1c50040a9909df6d88f836c7fcf2c1869bdb1c6e400d2f519fdeb89f62f

"C:\Program Files (x86)\NUnit.org\nunit-console\nunit3-console.exe" --inprocess C:\Users\bob_b\tictactoe_selenium_proto\TicTacToe_Test\bin\Debug\net6.0\TicTacToe_Test.dll




REM shutdown /s

pause
