pipeline{
	agent any
	stages {

	stage('Checkout') {
			steps {
				echo 'Checking out code...'
				checkout scm
			}
		}

		stage('Build') {
			steps {
				echo 'Building...'
				script{
					// Restoring NuGet packages
					bat "dotnet restore"

					// Building the project
					bat "dotnet build --configuration Release"
				}
			}
		}

		stage('Publish') {
			steps {
				echo 'Publishing...'
				script{
					// Publishing the project
					bat "dotnet publish --configuration Release --output ./publish"
				}
			}
		}
	}
	post {
		success {
			echo 'Checkout Build Publish successful.'
		}
	}}