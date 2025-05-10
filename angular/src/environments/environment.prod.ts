import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

const oAuthConfig = {
  issuer: 'https://localhost:44362/',
  redirectUri: baseUrl,
  clientId: 'TodoListApp_App',
  responseType: 'code',
  scope: 'offline_access TodoListApp',
  requireHttps: true,
};

export const environment = {
  production: true,
  application: {
    baseUrl,
    name: 'TodoListApp',
  },
  oAuthConfig,
  apis: {
    default: {
      url: 'https://localhost:44362',
      rootNamespace: 'TodoListApp',
    },
    AbpAccountPublic: {
      url: oAuthConfig.issuer,
      rootNamespace: 'AbpAccountPublic',
    },
  },
  remoteEnv: {
    url: '/getEnvConfig',
    mergeStrategy: 'deepmerge'
  }
} as Environment;
