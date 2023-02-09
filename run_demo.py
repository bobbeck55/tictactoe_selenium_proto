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
p = subprocess.Popen([r'start', r'cmd', '/k', r'git', r'checkout', r'demo_v1', r'npm', r'start'], cwd="../tictactoe_react_proto", shell=True)

#subprocess.check_output("git checkout demo_selenium_v1", shell=True)


if len(sys.argv) == 5 and sys.argv[2] == 'percy':
    cmd = r'node_modules\\.bin\\percy'
    arg1 = r'exec'
    arg2 = r'--'
    arg3 = r'dotnet'
    arg4 = r'test'
    arg5 = r'--no-restore'

    subprocess.Popen([cmd, arg1, arg2, arg3, arg4, arg5], env=myEnv, shell=True)

else:

    subprocess.Popen([cmd, arg3, arg4, arg4], env=myEnv, shell=True)












