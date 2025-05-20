# Default target: build
.PHONY: all
all: build

.PHONY: build
build:
	@echo "Building solution..."
	cd src && dotnet build --configuration Release

.PHONY: test
test:
	@echo "Running tests..."
	cd src && dotnet test --configuration Release

.PHONY: lint
lint:
	@echo "Checking code format..."
	cd src && dotnet format --verify-no-changes

.PHONY: clean
clean:
	@echo "Cleaning..."
	cd src && dotnet clean

publish: build
	dotnet publish /workspace/roverlib-c-sharp/src/roverlib/roverlib.csproj -c Release -f netstandard2.1 -o ./publish

# Extra testing to run the sample file
sample: build
	@echo "Running Sample..."
	touch /workspace/roverlib-c-sharp/sample.csx
	cd src && dotnet script /workspace/roverlib-c-sharp/sample.csx --no-cache --no-restore --debug --output /workspace/roverlib-c-sharp/logs.txt