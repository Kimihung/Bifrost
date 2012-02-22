﻿Bifrost.namespace("Bifrost.validation.ruleHandlers");
Bifrost.validation.ruleHandlers.minLength = {
    validate: function (value, options) {
        if (typeof options === "undefined" || typeof options.min === "undefined") {
            throw {
                message: "min is not specified for the minLength validator"
            }
        }

        return value.length >= options.min;
    }
};
