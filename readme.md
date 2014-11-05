# SimpleTemplateEngine

## Template elements

### Model specification

```
    <!--{{ MODEL
    <propertyName> : <propertyType (boolean, string, list)>
    }}-->
```

Describes how is the expected model, it is removed on template rendering.

Consists in a list of properties and types.

For `list` types, indentation is incremented and it has a list of the properties and types of each element.

### Print

```
    {{= <string propertyName> }}
```

Replace the element with current property value.

### Positive Condition

```
    <!--{{ IF #<identificator> <boolean propertyName> }}-->
    <TEXT BLOCK>
    <!--{{ ENDIF #<identificator> }}-->
```

Allow to specify to render a `TEXT BLOCK` only if the condition is true.

`identificator` is required, it is an arbitrary name and cannot be used more than a time in the same template.

`TEXT BLOCK` could be a template.

### Negative Condition

```
    <!--{{ IFNOT #<identificator> <boolean propertyName> }}-->
    <TEXT BLOCK>
    <!--{{ ENDIFNOT #<identificator> }}-->
```

Allow to specify to render a `TEXT BLOCK` only if the condition is false.

`identificator` is required, it is an arbitrary name and cannot be used more than a time in the same template.

`TEXT BLOCK` could be a template.

### Repeating

```
    <!--{{ EACH #<identificator> <list propertyName> }}-->
    <TEXT BLOCK>
    <!--{{ ENDEACH #<identificator> }}-->
```

Allow to specify to repeat a `TEXT BLOCK` for each item of the list property.

`TEXT BLOCK` could be a template and the item will be used to replace the placeholders.

## Limitations

* Templates element matching will be literal, including the spaces.
* It is required to specify an unique identifier for conditional or repeating template elements.
* All template elements should be closed
