require 'bundler/setup'

require 'albacore'
require 'albacore/tasks/versionizer'

Albacore::Tasks::Versionizer.new :versioning

build :build => [:versioning] do |b|
  b.sln = 'src/log4net.RabbitMQ.sln'
end

task :create_nugets => [:versioning, :build] do |p|
  sh "src/.nuget/NuGet.exe pack src/log4net.RabbitMQ/log4net.RabbitMQ.csproj -Version #{ENV['NUGET_VERSION']}"
end

task :nuget_publish => [:create_nugets] do |nuget|
    sh "src/.nuget/NuGet.exe push #{ENV["NugetOrgApiKey"]} log4net.RabbitMQAppender.#{ENV['NUGET_VERSION']}.nupkg"
end

task :default => :create_nugets