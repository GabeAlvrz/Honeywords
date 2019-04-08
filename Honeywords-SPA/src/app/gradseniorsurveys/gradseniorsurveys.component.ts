import { Component, OnInit, Output, Input, EventEmitter, Injectable } from '@angular/core';
import * as Survey from 'survey-angular';
import * as widgets from 'surveyjs-widgets';
import { environment } from '../../environments/environment';
import 'inputmask/dist/inputmask/phone-codes/phone.js';
import { AlertifyService } from '../_services/alertify.service';
import { HttpClient } from '@angular/common/http';
import { AuthService } from '../_services/auth.service';
import { Observable } from 'rxjs';
import { ActivatedRoute } from '@angular/router';
import { UserService } from '../_services/user.service';
import {Injector} from '@angular/core';

export let InjectorInstance: Injector;

widgets.icheck(Survey);
widgets.select2(Survey);
widgets.inputmask(Survey);
widgets.jquerybarrating(Survey);
widgets.jqueryuidatepicker(Survey);
widgets.nouislider(Survey);
widgets.select2tagbox(Survey);
widgets.signaturepad(Survey);
widgets.sortablejs(Survey);
widgets.ckeditor(Survey);
widgets.autocomplete(Survey);
widgets.bootstrapslider(Survey);
widgets.prettycheckbox(Survey);

Survey.Survey.cssType = 'bootstrap';
Survey.JsonObject.metaData.addProperty('questionbase', 'popupdescription:text');
Survey.JsonObject.metaData.addProperty('page', 'popupdescription:text');


@Component({
  selector: 'app-gradseniorsurveys',
  templateUrl: './gradseniorsurveys.component.html',
  styleUrls: ['./gradseniorsurveys.component.css']
})
export class GradseniorsurveysComponent implements OnInit {
  @Output() submitSurvey = new EventEmitter<any>();

  @Input()
  json: object;

  surveyJson: any = {
    pages: [
      {
        elements: [
          {
            type: 'html',
            html: '<h3 class=\'ml-3\'>General Information</h3>'
          },
          {
            type: 'text',
            name: 'surveyDate',
            title: 'Date',
            width: '300px',
            titleLocation: 'left',
            inputType: 'date'
          },
          {
            type: 'dropdown',
            title: 'Term of Expected Graduation',
            name: 'termGraduateSemester',
            width: '450px',
            choices: [
              'Spring',
              'Summer',
              'Fall'
            ],
            titleLocation: 'left',
            startWithNewLine: false
          },
          {
            type: 'text',
            name: 'termGraduateYear',
            width: '200px',
            title: 'Year',
            titleLocation: 'left',
            defaultValue: '20',
            startWithNewLine: false
          },
          {
            type: 'dropdown',
            title: 'Degree Program',
            name: 'degreeProgram',
            width: '300px',
            choices: [
              'B.A.',
              'B.S.'
            ],
            titleLocation: 'left',
            startWithNewLine: false
          },
          {
            name: 'Obj1',
            title: 'Objective 1: To provide students with a solid foundation in Computer Science,' +
                   'Mathematics, and Basic Sciences, which will allow them to successfully pursue ' +
                   'graduate studies in Computer Science, or other related degrees.',
            type: 'radiogroup',
            colCount: 4,
            choices: ['Exceeds Expectation', 'Meet Expectations', 'Marginally Acceptable', 'Unacceptable'],
            isRequired: true
          },
          {
            name: 'Obj2',
            title: 'Objective 2: To provide students with a solid foundation in Computer Science,' +
                   'Mathematics, and Basic Sciences, which will allow them to successfully compete ' +
                   'for quality jobs in all functions of Computer Science employment, ranging from ' +
                   'software developer to customer support.',
            type: 'radiogroup',
            colCount: 4,
            choices: ['Exceeds Expectation', 'Meet Expectations', 'Marginally Acceptable', 'Unacceptable'],
            isRequired: false
          },
          {
            name: 'Obj3',
            title: 'Objective 3: To equip students with life-long learning skills, which will allow ' +
                   'them to successfully adapt to the evolving technologies throughout their ' +
                   'professional careers.',
            type: 'radiogroup',
            colCount: 4,
            choices: ['Exceeds Expectation', 'Meet Expectations', 'Marginally Acceptable', 'Unacceptable'],
            isRequired: false
          },
          {
            name: 'Obj4',
            title: 'Objective 4: To equip students with communication skills, which will allow ' +
                   'them to collaborate efficiently with other members of a team for the development ' +
                   'of large computer and software systems.',
            type: 'radiogroup',
            colCount: 4,
            choices: ['Exceeds Expectation', 'Meet Expectations', 'Marginally Acceptable', 'Unacceptable'],
            isRequired: false
          },
          {
            name: 'Obj5',
            title: 'Objective 5: To provide students with broad education neccesary to understand the ' +
                   'impact of computer technology in a global and societal context.',
            type: 'radiogroup',
            colCount: 4,
            choices: ['Exceeds Expectation', 'Meet Expectations', 'Marginally Acceptable', 'Unacceptable'],
            isRequired: false
          },
          {
            name: 'Outcome1',
            title: 'Outcome 1: Ability to effectively apply knowledge of computing and mathematics ' +
                   'to computer science problem.',
            type: 'radiogroup',
            colCount: 4,
            choices: ['Exceeds Expectation', 'Meet Expectations', 'Marginally Acceptable', 'Unacceptable'],
            isRequired: true
          },
          {
            name: 'Outcome2',
            title: 'Outcome 2: Ability to apply mathematical foundations, algorithmic principles, and ' +
                   'computer science theory in the modelingand design of computer-based systems in a way' +
                   'that demonstrates comprehension of the trade=offs involved in design choices',
            type: 'radiogroup',
            colCount: 4,
            choices: ['Exceeds Expectation', 'Meet Expectations', 'Marginally Acceptable', 'Unacceptable'],
            isRequired: true
          },
          {
            name: 'Outcome3',
            title: 'Outcome 3: Ability to design, implement and evaluate computer-based components, ' +
                   'systems, processes or programs to meet desired needs and specifications.',
            type: 'radiogroup',
            colCount: 4,
            choices: ['Exceeds Expectation', 'Meet Expectations', 'Marginally Acceptable', 'Unacceptable'],
            isRequired: true
          },
          {
            name: 'Outcome4',
            title: 'Outcome 4: Ability to apply, design, and develop principles in the construction of ' +
                   'software systems of varying complexity.',
            type: 'radiogroup',
            colCount: 4,
            choices: ['Exceeds Expectation', 'Meet Expectations', 'Marginally Acceptable', 'Unacceptable'],
            isRequired: true
          },
          {
            name: 'Outcome5',
            title: 'Outcome 5: Ability tand skills to effectively use state-of-the-art techniques and computing ' +
                   'tools for analysis, design, and implementation of computing systems.',
            type: 'radiogroup',
            colCount: 4,
            choices: ['Exceeds Expectation', 'Meet Expectations', 'Marginally Acceptable', 'Unacceptable'],
            isRequired: true
          },
          {
            name: 'Outcome6',
            title: 'Outcome 6: Ability to function effectively as a member of a team assembled to undertake ' +
                   'a common goal.',
            type: 'radiogroup',
            colCount: 4,
            choices: ['Exceeds Expectation', 'Meet Expectations', 'Marginally Acceptable', 'Unacceptable'],
            isRequired: true
          },
          {
            name: 'Outcome7',
            title: 'Outcome 7: An understanding of professional, ethical, legal, security, and ' +
                   'social issues and responsibilities.',
            type: 'radiogroup',
            colCount: 4,
            choices: ['Exceeds Expectation', 'Meet Expectations', 'Marginally Acceptable', 'Unacceptable'],
            isRequired: true
          },
          {
            name: 'Outcome8',
            title: 'Outcome 8: Ability to communicate effectively to both technical and non-technical audiences. ',
            type: 'radiogroup',
            colCount: 4,
            choices: ['Exceeds Expectation', 'Meet Expectations', 'Marginally Acceptable', 'Unacceptable'],
            isRequired: true
          },
          {
            name: 'Outcome9',
            title: 'Outcome 9: Ability to analyze the local and global impact of computing on individuals ' +
            ', organizations and society. ',
            type: 'radiogroup',
            colCount: 4,
            choices: ['Exceeds Expectation', 'Meet Expectations', 'Marginally Acceptable', 'Unacceptable'],
            isRequired: true
          },
          {
            name: 'Outcome10',
            title: 'Outcome 10: Recognition of the need for and the ability to engage in life-long' +
            'learning. The ability to successfully pursue professional development ',
            type: 'radiogroup',
            colCount: 4,
            choices: ['Exceeds Expectation', 'Meet Expectations', 'Marginally Acceptable', 'Unacceptable'],
            isRequired: true
          },
        ]
      }
    ]
  };
  baseUrl = environment.apiUrl;
  constructor(private userService: UserService, private authService: AuthService,
    private http: HttpClient, private injector: Injector,
    private route: ActivatedRoute, private alertify: AlertifyService) {InjectorInstance = this.injector; }

  ngOnInit() {
    const surveyModel = new Survey.Model(this.surveyJson);
    surveyModel.onComplete.add(this.sendDataToServer);
    surveyModel.showQuestionNumbers = 'off';
    Survey.StylesManager.applyTheme('bootstrap');
    Survey.defaultBootstrapCss.navigationButton = 'btn btn-primary';
    Survey.SurveyNG.render('surveyElement', { model: surveyModel });
  }

  sendDataToServer(surveyModel) {
    const objSurvey = new ClassGradSeniorSurvey();
    // console.log(JSON.stringify(surveyModel.data));
    objSurvey.sendData(surveyModel.data);
  }

}
export class ClassGradSeniorSurvey implements OnInit {
  baseUrl = environment.apiUrl;
  private http: HttpClient;
  constructor() {
    this.http = InjectorInstance.get<HttpClient>(HttpClient);
  }

  ngOnInit() {}

  output2Console(surveyData) {
    console.log(surveyData);
  }

  sendData(surveyData) {
    console.log(surveyData);
    this.http.post( this.baseUrl + 'GradSeniorSurveys', surveyData).subscribe(
      (res: any) => {
        console.log('Graduate Senior Survey Updated');
      }, error => {
        console.log('Graduate Senior Update Error');
      }
    );
  }
}
