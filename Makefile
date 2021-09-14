all:
	dotnet publish Source -c Release --self-contained -r linux-x64 /p:PublishSingleFile=true
	dotnet publish Source -c Release --self-contained -r win-x64 /p:PublishSingleFile=true

clean:
	rm -rf Source/bin Source/obj