require 'bundler/setup'

require 'albacore'
require 'albacore/tasks/versionizer'

Albacore::Tasks::Versionizer.new :versioning

desc 'restore all nuget pkgs'
nugets_restore :restore do |r|
  r.out = 'src/packages'
  r.exe = 'src/.nuget/NuGet.exe'
  r.list_spec = 'src/**/packages.config' # don't include anything in Ruby vendor folders!
end

'build the solution'
build :build => [:versioning, :restore] do |b|
  b.sln = 'src/log4net.RabbitMQ.sln'
end

desc 'create nugets from the build'
task :create_nugets => [:versioning, :build] do |p|
  sh "src/.nuget/NuGet.exe pack src/log4net.RabbitMQ/log4net.RabbitMQ.csproj -Version #{ENV['NUGET_VERSION']}"
end

desc 'publish nugets'
task :nuget_publish => [:create_nugets] do |nuget|
    sh "src/.nuget/NuGet.exe push #{ENV["NugetOrgApiKey"]} log4net.RabbitMQAppender.#{ENV['NUGET_VERSION']}.nupkg"
end

desc 'runs create_nugets'
task :default => :create_nugets