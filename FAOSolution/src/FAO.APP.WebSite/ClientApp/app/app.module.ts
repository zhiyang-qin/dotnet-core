import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { UniversalModule } from 'angular2-universal';

import { AppComponent } from './components/app/app.component'
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { AppRoutingModule, routedComponents } from './app-routing.module';

import { AssetsModule } from './feature-modules/assets/assets.module'
import { DepreciateModule } from './feature-modules/depreciate/depreciate.module'
import { ToolsModule } from './feature-modules/tools/tools.module'

@NgModule({
    imports: [
        UniversalModule, // Must be first import. This automatically imports BrowserModule, HttpModule, and JsonpModule too.
        AssetsModule,
        DepreciateModule,
        ToolsModule,
        AppRoutingModule
    ],
    declarations: [
        AppComponent,
        NavMenuComponent,
        routedComponents
    ],
    bootstrap: [AppComponent]
})
export class AppModule {
}
