# NServiceBus.CustomChecks.SqlServer

[![Build status](https://img.shields.io/appveyor/build/TraGicCode/NServiceBus-CustomChecks-SqlServer/master)](https://ci.appveyor.com/project/TraGicCode/NServiceBus-CustomChecks-SqlServer)
[![Nuget](https://img.shields.io/nuget/v/NServiceBus.CustomChecks.SqlServer)](https://www.nuget.org/packages/NServiceBus.CustomChecks.SqlServer)
[![Nuget downloads](https://img.shields.io/nuget/dt/NServiceBus.CustomChecks.SqlServer)](https://www.nuget.org/packages/NServiceBus.CustomChecks.SqlServer)
[![License](https://img.shields.io/github/license/TraGicCode/NServiceBus.CustomChecks.SqlServer.svg)](https://github.com/TraGicCode/NServiceBus.CustomChecks.SqlServer/blob/master/LICENSE)

#### Table of Contents

1. [Description](#description)
1. [How to use it](#how-to-use-it)
1. [How it works](#how-it-works)
1. [Development - Guide for contributing](#contributing)

## Description

A Reusable NServiceBus CustomCheck to check the availability and connectivity of Sql Server.

## How to use it

In order to begin using this custom check simply create a child class for each instance you would like to perform a healthcheck on.

```c#
namespace Ordering.Endpoint.CustomChecks
{
    public class OrderingSqlServerCustomCheck : SqlServerCustomCheck
    {
        private const string ConnectionString =
            "Data Source=(local);Initial Catalog=Ordering;Integrated Security=True";

        public OrderingSqlServerCustomCheck() : base(ConnectionString, TimeSpan.FromSeconds(10))
        {
        }
    }
}
```

## Contributing

1. Fork it ( <https://github.com/tragiccode/NServiceBus.CustomChecks.SqlServer/fork> )
1. Create your feature branch (`git checkout -b my-new-feature`)
1. Commit your changes (`git commit -am 'Add some feature'`)
1. Push to the branch (`git push origin my-new-feature`)
1. Create a new Pull Request