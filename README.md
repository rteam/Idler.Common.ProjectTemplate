安装模板
`dotnet new install ./SimpleMicroService`
`dotnet new install ./BaseMicroService`

卸载模板
`dotnet new uninstall ./SimpleMicroService`
`dotnet new uninstall ./BaseMicroService`

使用模板
`dotnet new sms -n 项目名称`
`dotnet new bms -n 项目名称`

`sms` 参数
`-C` 是否启用缓存，可选值：`true`、`false`，默认 `true`
`-E` 是否启用示例文件，可选值：`true`、`false`，默认 `true`

`bms` 参数
`-C` 是否启用缓存，可选值：`true`、`false`，默认 `true`
`-E` 是否启用示例文件，可选值：`true`、`false`，默认 `true`
`-D` 指定数据库类型，可选值：`PostgreSQL`、`MySQL`，默认 `PostgreSQL`
