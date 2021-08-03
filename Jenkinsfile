def app_name = "minesweeper"
def app_pool = "DefaultAppPool"

pipeline {
  agent any
  options {
    ansiColor('xterm')
  }
  environment {
    PATH = "$PATH:/usr/local/bin"
  }
  stages {
    stage('Build') {
      steps {
        sh 'msbuild'
      }
    }
    stage('Deploy') {
      steps {
        sh "ansible-playbook /etc/ansible/win-deploy.yml -i /etc/ansible/hosts --extra-vars 'app_name=${app_name} app_pool=${app_pool} source=${env.WORKSPACE}/bin/' "
      }
    }
  }
}
