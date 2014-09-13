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

directory 'build/pkg'

nugets_pack :create_nugets => ['build/pkg', :versioning, :build] do |p|
  p.files   = FileList['src/**/*.csproj'].
    exclude(/Fracture|Example|Tests|Spec|sample|packages/)
  p.out     = 'build/pkg'
  p.exe     = 'src/.nuget/NuGet.exe'
  p.with_metadata do |m|
    m.description = 'Log4net appender for RabbitMQ'
    m.authors = 'Henrik Feldt'
    m.project_url = 'https://github.com/haf/log4net.RabbitMQ'
    m.version = ENV['NUGET_VERSION']
    m.tags = 'rabbitmq log4net'
  end
end

desc 'publish nugets'
task :nuget_publish => [:create_nugets] do |nuget|
    sh "src/.nuget/NuGet.exe push #{ENV["NugetOrgApiKey"]} log4net.RabbitMQAppender.#{ENV['NUGET_VERSION']}.nupkg"
end

desc 'runs create_nugets'
task :default => :create_nugets