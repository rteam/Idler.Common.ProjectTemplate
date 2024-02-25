# 安装模板

dotnet new install ./BaseMicroService

# 卸载模板

dotnet new uninstall ./BaseMicroService

# 使用模板

dotnet new bms -n 项目名称 

| 参数 | 说明                                             | 默认值 |
| ---- | ------------------------------------------------ | ------ |
| -D   | 指定使用的数据库类型，可选参数：SQLServer、MySQL | MySQL  |
| -C   | 是否启用缓存，可选值：true、false                | true   |
| -E   | 是否启用示例文件，可选值：true、false                | true   |

