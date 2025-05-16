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

# Extra testing to run the sample file
sample: build
	@echo "Running Sample..."
	touch /workspace/roverlib-c-sharp/src/roverlib/sample.csx
	cd src && dotnet script /workspace/roverlib-c-sharp/sample.csx --debug --output /workspace/roverlib-c-sharp/logs.txt
