#
#
#  Run demo - selenium test of tictactoe react app
#  argv[1] - percy -> run with percy
#  argv[2] - PERCY_BRANCH=master|local
#  argv[3] - PERCH_TOKEN=<from percy.io>
#
#
import subprocess
import sys
import os

if len(sys.argv) != 1 and len(sys.argv) != 4:
    print("Unsupported number of arguments: ", len(sys.argv))
    sys.exit(-1)

myEnv = os.environ
if len(sys.argv) == 4:
    myEnv["PERCY_BRANCH"] = sys.argv[2]
    myEnv["PERCY_TOKEN"] = sys.argv[3]


# spawn a new cmd prompt window with "npm start"
p = subprocess.Popen([r'start', r'cmd', '/k', r'demo_cmd.bat'], shell=True)


arg3 = r'dotnet'
arg4 = r'test'
arg5 = r'--no-restore'


if len(sys.argv) == 4 and sys.argv[1] == 'percy':
    cmd = r'node_modules\\.bin\\percy'
    arg1 = r'exec'
    arg2 = r'--'

    subprocess.Popen([cmd, arg1, arg2, arg3, arg4, arg5], env=myEnv, shell=True)

else:

    subprocess.Popen([arg3, arg4, arg5], env=myEnv, shell=True)












