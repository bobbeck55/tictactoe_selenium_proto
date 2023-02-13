#
#
#  Run demo - selenium test of tictactoe react app
#  argv[1] - 'all' or test name
#  argv[2] - percy -> run with percy
#  argv[3] - PERCY_BRANCH=master|local
#  argv[4] - PERCH_TOKEN=<from percy.io>
#
#
import subprocess
import sys
import os

if len(sys.argv) != 2 and len(sys.argv) != 5:
    print("Unsupported number of arguments: ", len(sys.argv))
    sys.exit(-1)

myEnv = os.environ
if len(sys.argv) == 5:
    myEnv["PERCY_BRANCH"] = sys.argv[3]
    myEnv["PERCY_TOKEN"] = sys.argv[4]


# spawn a new cmd prompt window with "npm start"
p = subprocess.Popen([r'start', r'cmd', '/k', r'demo_cmd.bat'], shell=True)

arg3 = r'dotnet'
arg4 = r'test'

if sys.argv[1] == 'all':
    arg5 = arg6 = ''
else:
    arg5 = "--filter"
    arg6 = "Name=" + sys.argv[1]


arg7 = r'--no-restore'


if len(sys.argv) == 5 and sys.argv[2] == 'percy':
    cmd = r'node_modules\\.bin\\percy'
    arg1 = r'exec'
    arg2 = r'--'

    subprocess.Popen([cmd, arg1, arg2, arg3, arg4, arg5, arg6, arg7], env=myEnv, shell=True)

else:

    subprocess.Popen([arg3, arg4, arg5, arg6, arg7], env=myEnv, shell=True)












