export interface Teacher{
  id: number,
  teacherBackground: string,
  user: {
    id: number,
    firstName: string,
    lastName: string,
    profileImage: string
  }
}
export interface Student{
  id: number,
  enrolledModulesNum: number,
  user: {
    id: number,
    firstName: string,
    lastName: string,
    profileImage: string
  }
}
export interface Module{
  moduleId: number,
  moduleName: string,
  moduleDescription: string
}
export interface Assignment{
    assignmentId: number,
    assignmentName: string,
    assignmentDescription: string,
    createdDate: Date
}

export interface ModuleStudent{
  module:{
    moduleId: number,
    moduleName: string,
    moduleDescription: string
  },
  student:{
    id: number,
    user:{
      firstName: string,
      lastName: string,
      email: string
    }
  }
}

export interface Grade{
  gradeId:number,
  score: number,
  feedback: string,
  student:{
    id:number,
    user:{
      firstName:string,
      lastName:string,
      email:string
    }
  }
}
export interface GradeDto{
  gradeId:number,
  score: number,
  feedback: string
}

export interface GradeStudent{
  gradeId:number,
  score:number,
  feedback:string,
  assignment:{
    assignmentId:number,
    assignmentName:string,
    assignmentDescription:string,
    module:{
      moduleId:number,
      moduleName:string,
      moduleDescription:string
    }
  }
}

export interface TeacherForm{
  id: number,
  teacherBackground: string,
  user: {
    id: number,
    firstName: string,
    lastName: string,
    profileImage: string,
    emailAddress:string,
    password:string,
    confirmPassword:string
  }
}

export interface StudentForm{
  id: number,
  enrolledModulesNum: number,
  user: {
    id: number,
    firstName: string,
    lastName: string,
    profileImage: string,
    emailAddress:string,
    password:string,
    confirmPassword:string
  }
}
