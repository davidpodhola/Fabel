namespace Fable.Import
open System

type private ImportAttribute(path) =
    inherit Attribute()

type private GlobalAttribute() =
    inherit Attribute()
    
type Function =
    abstract $inject: ResizeArray<string> option with get, set

module Globals =
    let [<Global>] angular: angular.IAngularStatic = failwith "JS only"

module angular =




module angular =
    type IServiceProviderClass =
        abstract createNew: [<ParamArray>] args: obj[] -> IServiceProvider

    and IServiceProviderFactory =
        interface end

    and IServiceProvider =
        abstract $get: obj with get, set

    and IAngularBootstrapConfig =
        abstract strictDi: bool option with get, set
        abstract debugInfoEnabled: bool option with get, set

    and IAngularStatic =
        abstract element: IAugmentedJQueryStatic with get, set
        abstract version: obj with get, set
        abstract bind: context: obj * fn: (obj->obj) * [<ParamArray>] args: obj[] -> (obj->obj)
        abstract bootstrap: element: U4<string, Element, JQuery, Document> * ?modules: ResizeArray<obj> * ?config: IAngularBootstrapConfig -> auto.IInjectorService
        abstract copy: source: 'T * ?destination: 'T -> 'T
        abstract equals: value1: obj * value2: obj -> bool
        abstract extend: destination: obj * [<ParamArray>] sources: obj[] -> obj
        abstract forEach: obj: ResizeArray<'T> * iterator: Func<'T, float, obj> * ?context: obj -> obj
        abstract forEach: obj: obj * iterator: Func<'T, string, obj> * ?context: obj -> obj
        abstract forEach: obj: obj * iterator: Func<obj, obj, obj> * ?context: obj -> obj
        abstract fromJson: json: string -> obj
        abstract identity: ?arg: 'T -> 'T
        abstract injector: ?modules: ResizeArray<obj> * ?strictDi: bool -> auto.IInjectorService
        abstract isArray: value: obj -> bool
        abstract isDate: value: obj -> bool
        abstract isDefined: value: obj -> bool
        abstract isElement: value: obj -> bool
        abstract isFunction: value: obj -> bool
        abstract isNumber: value: obj -> bool
        abstract isObject: value: obj -> bool
        abstract isString: value: obj -> bool
        abstract isUndefined: value: obj -> bool
        abstract lowercase: str: string -> string
        abstract merge: dst: obj * [<ParamArray>] src: obj[] -> obj
        abstract ``module``: name: string * ?requires: ResizeArray<string> * ?configFn: (obj->obj) -> IModule
        abstract noop: [<ParamArray>] args: obj[] -> unit
        abstract reloadWithDebugInfo: unit -> unit
        abstract toJson: obj: obj * ?pretty: bool -> string
        abstract uppercase: str: string -> string
        abstract resumeBootstrap: ?extraModules: ResizeArray<string> -> undefined.IInjectorService

    and IModule =
        abstract name: string with get, set
        abstract requires: ResizeArray<string> with get, set
        abstract animation: name: string * animationFactory: (obj->obj) -> IModule
        abstract animation: name: string * inlineAnnotatedFunction: ResizeArray<obj> -> IModule
        abstract animation: ``object``: obj -> IModule
        abstract ``component``: name: string * options: IComponentOptions -> IModule
        abstract config: configFn: (obj->obj) -> IModule
        abstract config: inlineAnnotatedFunction: ResizeArray<obj> -> IModule
        abstract config: ``object``: obj -> IModule
        abstract constant: name: string * value: obj -> IModule
        abstract constant: ``object``: obj -> IModule
        abstract controller: name: string * controllerConstructor: (obj->obj) -> IModule
        abstract controller: name: string * inlineAnnotatedConstructor: ResizeArray<obj> -> IModule
        abstract controller: ``object``: obj -> IModule
        abstract directive: name: string * directiveFactory: IDirectiveFactory -> IModule
        abstract directive: name: string * inlineAnnotatedFunction: ResizeArray<obj> -> IModule
        abstract directive: ``object``: obj -> IModule
        abstract factory: name: string * $getFn: (obj->obj) -> IModule
        abstract factory: name: string * inlineAnnotatedFunction: ResizeArray<obj> -> IModule
        abstract factory: ``object``: obj -> IModule
        abstract filter: name: string * filterFactoryFunction: (obj->obj) -> IModule
        abstract filter: name: string * inlineAnnotatedFunction: ResizeArray<obj> -> IModule
        abstract filter: ``object``: obj -> IModule
        abstract provider: name: string * serviceProviderFactory: IServiceProviderFactory -> IModule
        abstract provider: name: string * serviceProviderConstructor: IServiceProviderClass -> IModule
        abstract provider: name: string * inlineAnnotatedConstructor: ResizeArray<obj> -> IModule
        abstract provider: name: string * providerObject: IServiceProvider -> IModule
        abstract provider: ``object``: obj -> IModule
        abstract run: initializationFunction: (obj->obj) -> IModule
        abstract run: inlineAnnotatedFunction: ResizeArray<obj> -> IModule
        abstract service: name: string * serviceConstructor: (obj->obj) -> IModule
        abstract service: name: string * inlineAnnotatedConstructor: ResizeArray<obj> -> IModule
        abstract service: ``object``: obj -> IModule
        abstract value: name: string * value: obj -> IModule
        abstract value: ``object``: obj -> IModule
        abstract decorator: name: string * decoratorConstructor: (obj->obj) -> IModule
        abstract decorator: name: string * inlineAnnotatedConstructor: ResizeArray<obj> -> IModule

    and IAttributes =
        abstract $attr: obj with get, set
        abstract $normalize: name: string -> string
        abstract $addClass: classVal: string -> unit
        abstract $removeClass: classVal: string -> unit
        abstract $set: key: string * value: obj -> unit
        abstract $observe: name: string * fn: Func<'T, obj> -> (obj->obj)

    and IFormController =
        abstract $pristine: bool with get, set
        abstract $dirty: bool with get, set
        abstract $valid: bool with get, set
        abstract $invalid: bool with get, set
        abstract $submitted: bool with get, set
        abstract $error: obj with get, set
        abstract $addControl: control: INgModelController -> unit
        abstract $removeControl: control: INgModelController -> unit
        abstract $setValidity: validationErrorKey: string * isValid: bool * control: INgModelController -> unit
        abstract $setDirty: unit -> unit
        abstract $setPristine: unit -> unit
        abstract $commitViewValue: unit -> unit
        abstract $rollbackViewValue: unit -> unit
        abstract $setSubmitted: unit -> unit
        abstract $setUntouched: unit -> unit

    and INgModelController =
        abstract $viewValue: obj with get, set
        abstract $modelValue: obj with get, set
        abstract $parsers: ResizeArray<IModelParser> with get, set
        abstract $formatters: ResizeArray<IModelFormatter> with get, set
        abstract $viewChangeListeners: ResizeArray<IModelViewChangeListener> with get, set
        abstract $error: obj with get, set
        abstract $name: string with get, set
        abstract $touched: bool with get, set
        abstract $untouched: bool with get, set
        abstract $validators: IModelValidators with get, set
        abstract $asyncValidators: IAsyncModelValidators with get, set
        abstract $pending: obj with get, set
        abstract $pristine: bool with get, set
        abstract $dirty: bool with get, set
        abstract $valid: bool with get, set
        abstract $invalid: bool with get, set
        abstract $render: unit -> unit
        abstract $setValidity: validationErrorKey: string * isValid: bool -> unit
        abstract $setViewValue: value: obj * ?trigger: string -> unit
        abstract $setPristine: unit -> unit
        abstract $setDirty: unit -> unit
        abstract $validate: unit -> unit
        abstract $setTouched: unit -> unit
        abstract $setUntouched: unit -> unit
        abstract $rollbackViewValue: unit -> unit
        abstract $commitViewValue: unit -> unit
        abstract $isEmpty: value: obj -> bool

    and IModelValidators =
        interface end

    and IAsyncModelValidators =
        interface end

    and IModelParser =
        interface end

    and IModelFormatter =
        interface end

    and IModelViewChangeListener =
        interface end

    and IRootScopeService =
        abstract $parent: IScope with get, set
        abstract $root: IRootScopeService with get, set
        abstract $id: float with get, set
        abstract $isolateBindings: obj with get, set
        abstract $phase: obj with get, set
        abstract $apply: unit -> obj
        abstract $apply: exp: string -> obj
        abstract $apply: exp: Func<IScope, obj> -> obj
        abstract $applyAsync: unit -> obj
        abstract $applyAsync: exp: string -> obj
        abstract $applyAsync: exp: Func<IScope, obj> -> obj
        abstract $broadcast: name: string * [<ParamArray>] args: obj[] -> IAngularEvent
        abstract $destroy: unit -> unit
        abstract $digest: unit -> unit
        abstract $emit: name: string * [<ParamArray>] args: obj[] -> IAngularEvent
        abstract $eval: unit -> obj
        abstract $eval: expression: string * ?locals: obj -> obj
        abstract $eval: expression: Func<IScope, obj> * ?locals: obj -> obj
        abstract $evalAsync: unit -> unit
        abstract $evalAsync: expression: string -> unit
        abstract $evalAsync: expression: Func<IScope, obj> -> unit
        abstract $new: ?isolate: bool * ?parent: IScope -> IScope
        abstract $on: name: string * listener: Func<IAngularEvent, obj, obj> -> (obj->obj)
        abstract $watch: watchExpression: string * ?listener: string * ?objectEquality: bool -> (obj->obj)
        abstract $watch: watchExpression: string * ?listener: Func<'T, 'T, IScope, obj> * ?objectEquality: bool -> (obj->obj)
        abstract $watch: watchExpression: Func<IScope, obj> * ?listener: string * ?objectEquality: bool -> (obj->obj)
        abstract $watch: watchExpression: Func<IScope, 'T> * ?listener: Func<'T, 'T, IScope, obj> * ?objectEquality: bool -> (obj->obj)
        abstract $watchCollection: watchExpression: string * listener: Func<'T, 'T, IScope, obj> -> (obj->obj)
        abstract $watchCollection: watchExpression: Func<IScope, 'T> * listener: Func<'T, 'T, IScope, obj> -> (obj->obj)
        abstract $watchGroup: watchExpressions: ResizeArray<obj> * listener: Func<obj, obj, IScope, obj> -> (obj->obj)
        abstract $watchGroup: watchExpressions: ResizeArray<obj> * listener: Func<obj, obj, IScope, obj> -> (obj->obj)

    and IScope =
        inherit IRootScopeService

    and IRepeatScope =
        inherit IScope
        abstract $index: float with get, set
        abstract $first: bool with get, set
        abstract $middle: bool with get, set
        abstract $last: bool with get, set
        abstract $even: bool with get, set
        abstract $odd: bool with get, set

    and IAngularEvent =
        abstract targetScope: IScope with get, set
        abstract currentScope: IScope with get, set
        abstract name: string with get, set
        abstract stopPropagation: (obj->obj) option with get, set
        abstract preventDefault: (obj->obj) with get, set
        abstract defaultPrevented: bool with get, set

    and IWindowService =
        inherit Window

    and IBrowserService =
        abstract defer: angular.ITimeoutService with get, set

    and ITimeoutService =
        abstract cancel: ?promise: IPromise<obj> -> bool

    and IIntervalService =
        abstract cancel: promise: IPromise<obj> -> bool

    and IAnimateProvider =
        abstract register: name: string * factory: Func<IAnimateCallbackObject> -> unit
        abstract classNameFilter: ?expression: RegExp -> RegExp

    and IAnimateCallbackObject =
        abstract eventFn: element: Node * doneFn: Func<unit> -> (obj->obj)

    and IFilterService =
        interface end

    and IFilterFilter =
        interface end

    and IFilterFilterPatternObject =
        interface end

    and IFilterFilterPredicateFunc<'T> =
        interface end

    and IFilterFilterComparatorFunc<'T> =
        interface end

    and IFilterCurrency =
        interface end

    and IFilterNumber =
        interface end

    and IFilterDate =
        interface end

    and IFilterJson =
        interface end

    and IFilterLowercase =
        interface end

    and IFilterUppercase =
        interface end

    and IFilterLimitTo =
        interface end

    and IFilterOrderBy =
        interface end

    and IFilterProvider =
        inherit IServiceProvider
        abstract register: name: U2<string, obj> -> IServiceProvider

    and ILocaleService =
        abstract id: string with get, set
        abstract NUMBER_FORMATS: ILocaleNumberFormatDescriptor with get, set
        abstract DATETIME_FORMATS: ILocaleDateTimeFormatDescriptor with get, set
        abstract pluralCat: Func<obj, string> with get, set

    and ILocaleNumberFormatDescriptor =
        abstract DECIMAL_SEP: string with get, set
        abstract GROUP_SEP: string with get, set
        abstract PATTERNS: ResizeArray<ILocaleNumberPatternDescriptor> with get, set
        abstract CURRENCY_SYM: string with get, set

    and ILocaleNumberPatternDescriptor =
        abstract minInt: float with get, set
        abstract minFrac: float with get, set
        abstract maxFrac: float with get, set
        abstract posPre: string with get, set
        abstract posSuf: string with get, set
        abstract negPre: string with get, set
        abstract negSuf: string with get, set
        abstract gSize: float with get, set
        abstract lgSize: float with get, set

    and ILocaleDateTimeFormatDescriptor =
        abstract MONTH: ResizeArray<string> with get, set
        abstract SHORTMONTH: ResizeArray<string> with get, set
        abstract DAY: ResizeArray<string> with get, set
        abstract SHORTDAY: ResizeArray<string> with get, set
        abstract AMPMS: ResizeArray<string> with get, set
        abstract medium: string with get, set
        abstract short: string with get, set
        abstract fullDate: string with get, set
        abstract longDate: string with get, set
        abstract mediumDate: string with get, set
        abstract shortDate: string with get, set
        abstract mediumTime: string with get, set
        abstract shortTime: string with get, set

    and ILogService =
        abstract debug: ILogCall with get, set
        abstract error: ILogCall with get, set
        abstract info: ILogCall with get, set
        abstract log: ILogCall with get, set
        abstract warn: ILogCall with get, set

    and ILogProvider =
        inherit IServiceProvider
        abstract debugEnabled: unit -> bool
        abstract debugEnabled: enabled: bool -> ILogProvider

    and ILogCall =
        interface end

    and IParseService =
        interface end

    and IParseProvider =
        abstract logPromiseWarnings: unit -> bool
        abstract logPromiseWarnings: value: bool -> IParseProvider
        abstract unwrapPromises: unit -> bool
        abstract unwrapPromises: value: bool -> IParseProvider

    and ICompiledExpression =
        abstract literal: bool with get, set
        abstract constant: bool with get, set
        abstract assign: context: obj * value: obj -> obj

    and ILocationService =
        abstract absUrl: unit -> string
        abstract hash: unit -> string
        abstract hash: newHash: string -> ILocationService
        abstract host: unit -> string
        abstract path: unit -> string
        abstract path: path: string -> ILocationService
        abstract port: unit -> float
        abstract protocol: unit -> string
        abstract replace: unit -> ILocationService
        abstract search: unit -> obj
        abstract search: search: obj -> ILocationService
        abstract search: search: string * paramValue: U4<string, float, ResizeArray<string>, bool> -> ILocationService
        abstract state: unit -> obj
        abstract state: state: obj -> ILocationService
        abstract url: unit -> string
        abstract url: url: string -> ILocationService

    and ILocationProvider =
        inherit IServiceProvider
        abstract hashPrefix: unit -> string
        abstract hashPrefix: prefix: string -> ILocationProvider
        abstract html5Mode: unit -> bool
        abstract html5Mode: active: bool -> ILocationProvider
        abstract html5Mode: mode: obj -> ILocationProvider

    and IDocumentService =
        inherit IAugmentedJQuery

    and IExceptionHandlerService =
        interface end

    and IRootElementService =
        inherit JQuery

    and IQResolveReject<'T> =
        interface end

    and IQService =
        abstract createNew: resolver: Func<IQResolveReject<'T>, obj> -> IPromise<'T>
        abstract createNew: resolver: Func<IQResolveReject<'T>, IQResolveReject<obj>, obj> -> IPromise<'T>
        abstract all: promises: ResizeArray<IPromise<obj>> -> IPromise<ResizeArray<'T>>
        abstract all: promises: obj -> IPromise<obj>
        abstract all: promises: obj -> IPromise<'T>
        abstract defer: unit -> IDeferred<'T>
        abstract reject: ?reason: obj -> IPromise<obj>
        abstract resolve: value: U2<IPromise<'T>, 'T> -> IPromise<'T>
        abstract resolve: unit -> IPromise<unit>
        abstract ``when``: value: U2<IPromise<'T>, 'T> -> IPromise<'T>
        abstract ``when``: unit -> IPromise<unit>

    and IPromise<'T> =
        abstract ``then``: successCallback: Func<'T, U2<IPromise<TResult>, TResult>> * ?errorCallback: Func<obj, obj> * ?notifyCallback: Func<obj, obj> -> IPromise<TResult>
        abstract catch: onRejected: Func<obj, U2<IPromise<TResult>, TResult>> -> IPromise<TResult>
        abstract ``finally``: finallyCallback: Func<obj> -> IPromise<'T>

    and IDeferred<'T> =
        abstract promise: IPromise<'T> with get, set
        abstract resolve: ?value: U2<'T, IPromise<'T>> -> unit
        abstract reject: ?reason: obj -> unit
        abstract notify: ?state: obj -> unit

    and IAnchorScrollService =
        abstract yOffset: obj with get, set

    and IAnchorScrollProvider =
        inherit IServiceProvider
        abstract disableAutoScrolling: unit -> unit

    and ICacheFactoryService =
        abstract info: unit -> obj
        abstract get: cacheId: string -> ICacheObject

    and ICacheObject =
        abstract info: unit -> obj
        abstract put: key: string * ?value: 'T -> 'T
        abstract get: key: string -> 'T
        abstract remove: key: string -> unit
        abstract removeAll: unit -> unit
        abstract destroy: unit -> unit

    and ICompileService =
        interface end

    and ICompileProvider =
        inherit IServiceProvider
        abstract directive: name: string * directiveFactory: (obj->obj) -> ICompileProvider
        abstract directive: directivesMap: obj -> ICompileProvider
        abstract aHrefSanitizationWhitelist: unit -> RegExp
        abstract aHrefSanitizationWhitelist: regexp: RegExp -> ICompileProvider
        abstract imgSrcSanitizationWhitelist: unit -> RegExp
        abstract imgSrcSanitizationWhitelist: regexp: RegExp -> ICompileProvider
        abstract debugInfoEnabled: ?enabled: bool -> obj

    and ICloneAttachFunction =
        interface end

    and ITemplateLinkingFunction =
        interface end

    and ITranscludeFunction =
        interface end

    and IControllerService =
        interface end

    and IControllerProvider =
        inherit IServiceProvider
        abstract register: name: string * controllerConstructor: (obj->obj) -> unit
        abstract register: name: string * dependencyAnnotatedConstructor: ResizeArray<obj> -> unit
        abstract allowGlobals: unit -> unit

    and IHttpService =
        abstract defaults: IHttpProviderDefaults with get, set
        abstract pendingRequests: ResizeArray<IRequestConfig> with get, set
        abstract get: url: string * ?config: IRequestShortcutConfig -> IHttpPromise<'T>
        abstract delete: url: string * ?config: IRequestShortcutConfig -> IHttpPromise<'T>
        abstract head: url: string * ?config: IRequestShortcutConfig -> IHttpPromise<'T>
        abstract jsonp: url: string * ?config: IRequestShortcutConfig -> IHttpPromise<'T>
        abstract post: url: string * data: obj * ?config: IRequestShortcutConfig -> IHttpPromise<'T>
        abstract put: url: string * data: obj * ?config: IRequestShortcutConfig -> IHttpPromise<'T>
        abstract patch: url: string * data: obj * ?config: IRequestShortcutConfig -> IHttpPromise<'T>

    and IRequestShortcutConfig =
        inherit IHttpProviderDefaults
        abstract params: obj option with get, set
        abstract data: obj option with get, set
        abstract timeout: U2<float, IPromise<obj>> option with get, set
        abstract responseType: string option with get, set

    and IRequestConfig =
        inherit IRequestShortcutConfig
        abstract ``method``: string with get, set
        abstract url: string with get, set

    and IHttpHeadersGetter =
        interface end

    and IHttpPromiseCallback<'T> =
        interface end

    and IHttpPromiseCallbackArg<'T> =
        abstract data: 'T option with get, set
        abstract status: float option with get, set
        abstract headers: IHttpHeadersGetter option with get, set
        abstract config: IRequestConfig option with get, set
        abstract statusText: string option with get, set

    and IHttpPromise<'T> =
        inherit IPromise<IHttpPromiseCallbackArg<'T>>
        abstract success: callback: IHttpPromiseCallback<'T> -> IHttpPromise<'T>
        abstract error: callback: IHttpPromiseCallback<obj> -> IHttpPromise<'T>

    and IHttpRequestTransformer =
        interface end

    and IHttpResponseTransformer =
        interface end

    and IHttpRequestConfigHeaders =
        abstract common: U2<string, obj> option with get, set
        abstract get: U2<string, obj> option with get, set
        abstract post: U2<string, obj> option with get, set
        abstract put: U2<string, obj> option with get, set
        abstract patch: U2<string, obj> option with get, set

    and IHttpProviderDefaults =
        abstract cache: obj option with get, set
        abstract transformRequest: U2<IHttpRequestTransformer, ResizeArray<IHttpRequestTransformer>> option with get, set
        abstract transformResponse: U2<IHttpResponseTransformer, ResizeArray<IHttpResponseTransformer>> option with get, set
        abstract headers: IHttpRequestConfigHeaders option with get, set
        abstract xsrfHeaderName: string option with get, set
        abstract xsrfCookieName: string option with get, set
        abstract withCredentials: bool option with get, set
        abstract paramSerializer: U2<string, obj> option with get, set

    and IHttpInterceptor =
        abstract request: Func<IRequestConfig, U2<IRequestConfig, IPromise<IRequestConfig>>> option with get, set
        abstract requestError: Func<obj, obj> option with get, set
        abstract response: Func<IHttpPromiseCallbackArg<'T>, U2<IPromise<'T>, 'T>> option with get, set
        abstract responseError: Func<obj, obj> option with get, set

    and IHttpInterceptorFactory =
        interface end

    and IHttpProvider =
        inherit IServiceProvider
        abstract defaults: IHttpProviderDefaults with get, set
        abstract interceptors: ResizeArray<obj> with get, set
        abstract useApplyAsync: unit -> bool
        abstract useApplyAsync: value: bool -> IHttpProvider
        abstract useLegacyPromiseExtensions: value: bool -> U2<bool, IHttpProvider>

    and IHttpBackendService =
        interface end

    and IInterpolateService =
        abstract endSymbol: unit -> string
        abstract startSymbol: unit -> string

    and IInterpolationFunction =
        interface end

    and IInterpolateProvider =
        inherit IServiceProvider
        abstract startSymbol: unit -> string
        abstract startSymbol: value: string -> IInterpolateProvider
        abstract endSymbol: unit -> string
        abstract endSymbol: value: string -> IInterpolateProvider

    and ITemplateCacheService =
        inherit ICacheObject

    and ISCEService =
        abstract getTrusted: ``type``: string * mayBeTrusted: obj -> obj
        abstract getTrustedCss: value: obj -> obj
        abstract getTrustedHtml: value: obj -> obj
        abstract getTrustedJs: value: obj -> obj
        abstract getTrustedResourceUrl: value: obj -> obj
        abstract getTrustedUrl: value: obj -> obj
        abstract parse: ``type``: string * expression: string -> Func<obj, obj, obj>
        abstract parseAsCss: expression: string -> Func<obj, obj, obj>
        abstract parseAsHtml: expression: string -> Func<obj, obj, obj>
        abstract parseAsJs: expression: string -> Func<obj, obj, obj>
        abstract parseAsResourceUrl: expression: string -> Func<obj, obj, obj>
        abstract parseAsUrl: expression: string -> Func<obj, obj, obj>
        abstract trustAs: ``type``: string * value: obj -> obj
        abstract trustAsHtml: value: obj -> obj
        abstract trustAsJs: value: obj -> obj
        abstract trustAsResourceUrl: value: obj -> obj
        abstract trustAsUrl: value: obj -> obj
        abstract isEnabled: unit -> bool

    and ISCEProvider =
        inherit IServiceProvider
        abstract enabled: value: bool -> unit

    and ISCEDelegateService =
        abstract getTrusted: ``type``: string * mayBeTrusted: obj -> obj
        abstract trustAs: ``type``: string * value: obj -> obj
        abstract valueOf: value: obj -> obj

    and ISCEDelegateProvider =
        inherit IServiceProvider
        abstract resourceUrlBlacklist: blacklist: ResizeArray<obj> -> unit
        abstract resourceUrlWhitelist: whitelist: ResizeArray<obj> -> unit
        abstract resourceUrlBlacklist: unit -> ResizeArray<obj>
        abstract resourceUrlWhitelist: unit -> ResizeArray<obj>

    and ITemplateRequestService =
        abstract totalPendingRequests: float with get, set

    and Type =
        inherit (obj->obj)

    and RouteDefinition =
        abstract path: string option with get, set
        abstract aux: string option with get, set
        abstract ``component``: U3<Type, ComponentDefinition, string> option with get, set
        abstract loader: (obj->obj) option with get, set
        abstract redirectTo: ResizeArray<obj> option with get, set
        abstract ``as``: string option with get, set
        abstract name: string option with get, set
        abstract data: obj option with get, set
        abstract useAsDefault: bool option with get, set

    and ComponentDefinition =
        abstract ``type``: string with get, set
        abstract loader: (obj->obj) option with get, set
        abstract ``component``: Type option with get, set

    and IComponentOptions =
        abstract controller: obj option with get, set
        abstract controllerAs: string option with get, set
        abstract template: U2<string, (obj->obj)> option with get, set
        abstract templateUrl: U2<string, (obj->obj)> option with get, set
        abstract bindings: obj option with get, set
        abstract transclude: bool option with get, set
        abstract require: obj option with get, set
        abstract $canActivate: Func<bool> option with get, set
        abstract $routeConfig: ResizeArray<RouteDefinition> option with get, set

    and IComponentTemplateFn =
        interface end

    and IDirectiveFactory =
        interface end

    and IDirectiveLinkFn =
        interface end

    and IDirectivePrePost =
        abstract pre: IDirectiveLinkFn option with get, set
        abstract post: IDirectiveLinkFn option with get, set

    and IDirectiveCompileFn =
        interface end

    and IDirective =
        abstract compile: IDirectiveCompileFn option with get, set
        abstract controller: obj option with get, set
        abstract controllerAs: string option with get, set
        abstract bindToController: U2<bool, obj> option with get, set
        abstract link: U2<IDirectiveLinkFn, IDirectivePrePost> option with get, set
        abstract name: string option with get, set
        abstract priority: float option with get, set
        abstract replace: bool option with get, set
        abstract require: obj option with get, set
        abstract restrict: string option with get, set
        abstract scope: obj option with get, set
        abstract template: U2<string, (obj->obj)> option with get, set
        abstract templateNamespace: string option with get, set
        abstract templateUrl: U2<string, (obj->obj)> option with get, set
        abstract terminal: bool option with get, set
        abstract transclude: obj option with get, set

    and IAugmentedJQueryStatic =
        inherit JQueryStatic

    and IAugmentedJQuery =
        inherit JQuery
        abstract find: selector: string -> IAugmentedJQuery
        abstract find: element: obj -> IAugmentedJQuery
        abstract find: obj: JQuery -> IAugmentedJQuery
        abstract controller: unit -> obj
        abstract controller: name: string -> obj
        abstract injector: unit -> obj
        abstract scope: unit -> IScope
        abstract isolateScope: unit -> IScope
        abstract inheritedData: key: string * value: obj -> JQuery
        abstract inheritedData: obj: obj -> JQuery
        abstract inheritedData: ?key: string -> obj

    module auto =
        type IInjectorService =
            abstract annotate: fn: (obj->obj) -> ResizeArray<string>
            abstract annotate: inlineAnnotatedFunction: ResizeArray<obj> -> ResizeArray<string>
            abstract get: name: string * ?caller: string -> 'T
            abstract has: name: string -> bool
            abstract instantiate: typeConstructor: (obj->obj) * ?locals: obj -> 'T
            abstract invoke: inlineAnnotatedFunction: ResizeArray<obj> -> obj
            abstract invoke: func: (obj->obj) * ?context: obj * ?locals: obj -> obj

        and IProvideService =
            abstract constant: name: string * value: obj -> unit
            abstract decorator: name: string * decorator: (obj->obj) -> unit
            abstract decorator: name: string * inlineAnnotatedFunction: ResizeArray<obj> -> unit
            abstract factory: name: string * serviceFactoryFunction: (obj->obj) -> IServiceProvider
            abstract factory: name: string * inlineAnnotatedFunction: ResizeArray<obj> -> IServiceProvider
            abstract provider: name: string * provider: IServiceProvider -> IServiceProvider
            abstract provider: name: string * serviceProviderConstructor: (obj->obj) -> IServiceProvider
            abstract service: name: string * ``constructor``: (obj->obj) -> IServiceProvider
            abstract service: name: string * inlineAnnotatedFunction: ResizeArray<obj> -> IServiceProvider
            abstract value: name: string * value: obj -> IServiceProvider


