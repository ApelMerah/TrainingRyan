/*
 * Code generated by Microsoft (R) AutoRest Code Generator.
 * Changes may cause incorrect behavior and will be lost if the code is
 * regenerated.
 */

import * as msRest from "@azure/ms-rest-js";


export const RegisterApiRequestModel: msRest.CompositeMapper = {
  serializedName: "RegisterApiRequestModel",
  type: {
    name: "Composite",
    className: "RegisterApiRequestModel",
    modelProperties: {
      username: {
        required: true,
        serializedName: "username",
        constraints: {
          MaxLength: 64,
          MinLength: 4
        },
        type: {
          name: "String"
        }
      },
      password: {
        required: true,
        serializedName: "password",
        constraints: {
          MaxLength: 64,
          MinLength: 0
        },
        type: {
          name: "String"
        }
      }
    }
  }
};